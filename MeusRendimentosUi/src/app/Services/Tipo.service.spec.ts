/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { TipoService } from './Tipo.service';

describe('Service: TipoService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TipoService]
    });
  });

  it('should ...', inject([TipoService], (service: TipoService) => {
    expect(service).toBeTruthy();
  }));
});
