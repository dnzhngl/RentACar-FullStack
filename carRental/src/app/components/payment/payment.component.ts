import { CreditCard } from './../../models/creditCard';
import { ListResponseModel } from './../../models/responseModels/listResponseModel';
import { CreditCardService } from './../../services/credit-card.service';
import { RentalService } from './../../services/rental.service';
import { Component, Input, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css'],
})
export class PaymentComponent implements OnInit {
  @Input() rentFormValues: any;
  paymentForm: FormGroup;

  fakeConfirmationCode: string;
  confirmCodeInput: string;
  openModal: boolean = false;

  response: ListResponseModel<CreditCard>;

  constructor(
    private formBuilder: FormBuilder,
    private rentalService: RentalService,
    private toastrService: ToastrService,
    private creditCardService: CreditCardService
  ) {}

  ngOnInit(): void {
    this.createPaymentForm();
    console.log(Number(this.rentFormValues['customerId']));
    this.getCreditCardInfo(Number(this.rentFormValues['customerId']));
  }

  createPaymentForm() {
    this.paymentForm = this.formBuilder.group({
      paymentMethod: ['', Validators.required],
      nameOnCard: [''],
      ccNumber: ['', Validators.required],
      expirationMonth: ['', Validators.required],
      expirationYear: ['', Validators.required],
      cvv: ['', Validators.required],
      saveCreditCard: [false],
    });
  }
  patchForm(creditCard: CreditCard) {
    this.paymentForm.patchValue({
      nameOnCard: creditCard.nameOnCard,
      ccNumber: creditCard.ccNumber,
      expirationMonth: creditCard.expirationMonth,
      expirationYear : creditCard.expirationYear,
      cvv : creditCard.cvv
    });
  }
  getCreditCardInfo(customerId: number) {
    this.creditCardService.getCreditCards(customerId).subscribe((response) => {
      console.log(response);
      this.response = response;
    });
  }

  fakeConfirmCode() {
    if (this.paymentForm.valid) {
      this.fakeConfirmationCode = Math.random().toString(36).substring(7);
      this.toastrService.info('Confirmation Code', this.fakeConfirmationCode);
      this.openModal = true;
      console.log(this.fakeConfirmationCode);
    } else {
      this.toastrService.warning('Please fill in all fields.', 'Attention');
    }
  }

  checkCode() {
    if (this.confirmCodeInput === this.fakeConfirmationCode) {
      this.add();
      if (this.paymentForm.controls['saveCreditCard'].value === true) {
        let paymentModel = Object.assign({}, this.paymentForm.value);
        paymentModel.customerId = this.rentFormValues['customerId'];

        this.creditCardService.add(paymentModel).subscribe((response) => {
          this.toastrService.success(response.message, 'Success');
        });
        this.closeModal();
      }
    } else {
      this.toastrService.error('Confirmation code is wrong.', 'Attention');
    }
  }

  closeModal() {
    this.openModal = false;
  }

  add() {
    if (this.paymentForm.valid) {
      this.rentalService.add(this.rentFormValues).subscribe(
        (response) => {
          this.toastrService.success(response.message, 'Success');
        },
        (responseError) => {
          console.log(responseError);
          if (responseError.error.ValidationErrors?.length > 0) {
            for (
              let i = 0;
              i < responseError.error.ValidationErrors.length;
              i++
            ) {
              this.toastrService.error(
                responseError.error.ValidationErrors[i].ErrorMessage,
                'Validation Error'
              );
            }
          } else if (responseError.error) {
            this.toastrService.error(responseError.error.message);
          }
        }
      );
    } else {
      this.toastrService.warning('Please fill in all fields.', 'Attention');
    }
  }
}
