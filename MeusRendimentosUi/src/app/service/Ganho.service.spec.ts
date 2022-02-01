/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { GanhoService } from './Ganho.service';

describe('Service: Ganho', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [GanhoService]
    });
  });

  it('should ...', inject([GanhoService], (service: GanhoService) => {
    expect(service).toBeTruthy();
  }));
});
