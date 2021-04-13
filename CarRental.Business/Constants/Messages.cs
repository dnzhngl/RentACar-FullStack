using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Constants
{
    public static class Messages
    {
        public static string Error()
        {
            //return "Bir hata oluştu";
            return "Something went wrong";
        }
        public static string NotFound()
        {
            //return "Hiç bir kayıt bulunamadı.";
            return "No records were found";
        }
        public static class Brand
        {
            public static string Add(string brandName)
            {
                //return $"{brandName} isimli marka sisteme başarı ile eklenmiştir.";
                return $"The brand named {brandName} has been successfully added to the system.";
            }
            public static string Update(string brandName)
            {
                //return $"{brandName} isimli marka bilgileri başarılı bir şekilde güncellenmiştir.";
                return $"The brand named {brandName}'s information has been successfully updated.";
            }
            public static string Delete(string brandName)
            {
                //return $"{brandName} isimli marka başarılı bir şekilde silinmiştir.";
                return $"The brand named {brandName} has been successfully deleted from the system.";
            }
            public static string Exists(string brandName)
            {
                //return $"{brandName} aynı isimde bir marka sistemde mevcuttur.";
                return $"A brand named {brandName} is present in the system.";
            }
        }
        public static class Car
        {
            public static string Add(string model, string modelYear)
            {
                //return $"{model} - {modelYear} model araba sisteme başarı ile eklenmiştir.";
                return $"{model} - {modelYear} model car has been successfully added to the system.";
            }
            public static string Update(string model, string modelYear)
            {
                //return $"{model} - {modelYear} model araba bilgileri başarılı bir şekilde güncellenmiştir.";
                return $"The {model} - {modelYear} model car's information has been updated successfully.";
            }
            public static string Delete(string model, string modelYear)
            {
                //return $"{model} - {modelYear} model araba sistemden başarılı bir şekilde silinmiştir.";
                return $"{model} - {modelYear} model car has been successfully deleted from the system.";
            }
            public static string Exists(string model, string modelYear, string color)
            {
                //return $"{model} - {modelYear} - {color} bilgilerine sahip bir araba sistemde kayıtlıdır.";
                return $"A car with {model} - {modelYear} - {color} information is present in the system.";
            }

        }
        public static class CarType
        {
            public static string Add(string carTypeName)
            {
                //return $"{carTypeName} araba türü sisteme başarı ile eklenmiştir.";
                return $"The {carTypeName} car type has been successfully added to the system.";
            }
            public static string Update(string carTypeName)
            {
                //return $"{carTypeName} araba türü başarılı bir şekilde güncellenmiştir.";
                return $"The {carTypeName} car type has been successfully updated.";
            }
            public static string Delete(string carTypeName)
            {
                //return $"{carTypeName} araba türü sistemden başarılı bir şekilde silinmiştir.";
                return $"The car type {carTypeName} has been successfully deleted from the system.";
            }
            public static string Exists(string carTypeName)
            {
                //return $"{carTypeName} ismine sahip bir araba türü sistemde kayıtlıdır.";
                return $"A car type with the name {carTypeName} is present in the system.";
            }

        }
        public static class Color
        {
            public static string Add(string colorName)
            {
                //return $"{colorName} renk sisteme başarı ile eklenmiştir.";
                return $"The {colorName} color has been successfully added to the system.";
            }
            public static string Update(string colorName)
            {
                //return $"{colorName} renk bilgileri başarılı bir şekilde güncellenmiştir.";
                return $"The {colorName} color has been updated successfully.";
            }
            public static string Delete(string colorName)
            {
                //return $"{colorName} renk sistemden başarılı bir şekilde silinmiştir.";
                return $"The {colorName} color has been successfully deleted from the system.";
            }
            public static string Exists(string colorName)
            {
                //return $"{colorName} renk ismine sahip bir kayıt sistemde bulunmaktadır.";
                return $"A record with the color named {colorName} presents in the system.";
            }

        }
        public static class CorporateCustomer
        {
            public static string Add(string companyName)
            {
                //return $"{companyName} isimli müşteri sisteme başarı ile eklenmiştir.";
                return $"A customer named {companyName} has been successfully added to the system.";
            }
            public static string Update(string companyName)
            {
                //return $"{companyName} adlı müşterinin bilgileri başarılı bir şekilde güncellenmiştir.";
                return $"The {companyName}'s information has been updated successfully.";
            }
            public static string Delete(string companyName)
            {
                //return $"{companyName} adlı müşteri sistemden başarılı bir şekilde silinmiştir.";
                return $"The customer {companyName} has been successfully deleted from the system.";
            }
            public static string Exists(string companyName)
            {
                //return $"{companyName} bilgilerine sahip bir müşteri sistemde kayıtlıdır.";
                return $"A customer with {companyName} information is present in the system.";
            }

        }
        public static class IndividualCustomer
        {
            public static string Add(string customerFirstname, string customerLastname)
            {
                //return $"{customerFirstname} {customerLastname} isimli müşteri sisteme başarı ile eklenmiştir.";
                return $"A customer {customerFirstname} {customerLastname} has been successfully added to the system.";
            }
            public static string Update(string customerFirstname, string customerLastname)
            {
                //return $"{customerFirstname} {customerLastname} adlı müşterinin bilgileri başarılı bir şekilde güncellenmiştir.";
                return $"{customerFirstname} {customerLastname} has successfully updated their information.";
            }
            public static string Delete(string customerFirstname, string customerLastname)
            {
                //return $"{customerFirstname} {customerLastname} adlı müşteri sistemden başarılı bir şekilde silinmiştir.";
                return $"The customer {customerFirstname} {customerLastname} has been successfully deleted from the system.";
            }
            public static string Exists(string customerFirstname, string customerLastname)
            {
                //return $"{customerFirstname} {customerLastname} bilgilerine sahip bir müşteri sistemde kayıtlıdır.";
                return $"A customer named {customerFirstname} {customerLastname} is present in the system.";
            }

        }
        public static class Rental
        {
            public static string Add()
            {
                //return $"Araba kiralama sözleşmesi sisteme başarı ile eklenmiştir.";
                return $"The car rental agreement has been successfully added to the system.";
            }
            public static string Update()
            {
                //return $"Araba kiralama sözleşmesi bilgileri başarılı bir şekilde güncellenmiştir.";
                return $"The car rental agreement's information has been updated successfully.";
            }
            public static string Delete()
            {
                //return $"Araba kiralama sözleşmesi sistemden başarılı bir şekilde silinmiştir.";
                return $"The car rental agreement has been successfully deleted from the system.";
            }
            public static string Exists()
            {
                //return $"Sözleşmeye dahil edilen {carModel} - {carModelYear} model araba müsait değildir.";
                //return $"The {carModel} - {carModelYear} model car included in the contract is not available.";
                return $"The car included in the contract is not available.";
            }
        }
        public static class User
        {
            public static string Add()
            {
                //return $"Kullanıcı sisteme başarı ile eklenmiştir.";
                return $"The user has been successfully added to the system.";
            }
            public static string Update()
            {
                //return $"Kullanıcı bilgileri başarılı bir şekilde güncellenmiştir.";
                return $"User information has been successfully updated.";
            }
            public static string Delete()
            {
                //return $"Kullanıcı sistemden başarılı bir şekilde silinmiştir.";
                return $"The user has been successfully deleted from the system.";
            }
            public static string Exists(string emailAddress)
            {
                //return $"{emailAddress} bilgilerine sahip bir kullanıcı sistemde kayıtlıdır.";
                return $"A user with {emailAddress} information is present.";
            }
            public static string NotFound()
            {
                //return "Kullanıcı bulunamadı";
                return "User not found.";
            }
            public static string PasswordChange()
            {
                return $"User password has been successfully changed.";
            }
        }
        public static class CarImage
        {
            public static string Add(bool isPlural)
            {
                if (isPlural)
                {
                    //return $"Fotoğraflar sisteme başarı ile eklenmiştir.";
                    return $"Photos have been successfully added to the system.";
                }
                //return $"Fotoğraf sisteme başarı ile eklenmiştir.";
                return $"The photo has been successfully added to the system.";
            }
            public static string Update(bool isPlural)
            {
                if (isPlural)
                {
                    //return $"Fotoğraflar başarılı bir şekilde güncellenmiştir.";
                    return $"Photos have been successfully updated.";
                }
                //return $"Fotoğraf başarılı bir şekilde güncellenmiştir.";
                return $"The photo has been successfully updated.";
            }
            public static string Delete(bool isPlural)
            {
                if (isPlural)
                {
                    //return $"Fotoğraflar sistemden başarılı bir şekilde silinmiştir.";
                    return $"Photos have been successfully deleted from the system.";
                }
                //return $"Fotoğraf sistemden başarılı bir şekilde silinmiştir.";
                return $"The photo has been successfully deleted from the system.";
            }
            public static string NumberOfPhotografsHasReachedLimit(int limit)
            {
                //return $"Bir arabanın en fazla {limit} fotoğrafı olabilir.";
                return $"A car can have a maximum of {limit} photos.";
            }

        }

        public static class Authorization
        {
            public static string AuthorizationDenied()
            {
                //return "Yetkiniz yoktur.";
                return "You are not authorized.";
            }
        }
        public static class Authentication
        {
            //public static string PasswordError = "Şifre hatalı";
            //public static string SuccessfulLogin = "Sisteme giriş başarılı";
            //public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
            //public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
            //public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";
            public static string PasswordError = "The password is incorrect";
            public static string SuccessfulLogin = "Login to the system is successful";
            public static string UserAlreadyExists = "This user already exists";
            public static string UserRegistered = "User successfully registered";
            public static string AccessTokenCreated = "Access token successfully created";
        }
    }
}
