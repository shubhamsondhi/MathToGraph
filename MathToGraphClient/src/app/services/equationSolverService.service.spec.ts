/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { EquationSolverServiceService } from './equationSolverService.service';

describe('Service: EquationSolverService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [EquationSolverServiceService]
    });
  });

  it('should ...', inject([EquationSolverServiceService], (service: EquationSolverServiceService) => {
    expect(service).toBeTruthy();
  }));
});
