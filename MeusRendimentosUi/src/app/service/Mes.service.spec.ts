/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { MesService } from './Mes.service';

describe('Service: Mes', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [MesService]
    });
  });

  it('should ...', inject([MesService], (service: MesService) => {
    expect(service).toBeTruthy();
  }));
});
