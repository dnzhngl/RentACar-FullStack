import { FilterByBrandPipe } from './filter-by-brand.pipe';

describe('FilterByBrandPipe', () => {
  it('create an instance', () => {
    const pipe = new FilterByBrandPipe();
    expect(pipe).toBeTruthy();
  });
});
