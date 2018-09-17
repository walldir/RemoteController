import { TestBed, inject } from '@angular/core/testing';

import { MachinesService } from './machines.service';

describe('MachinesService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [MachinesService]
    });
  });

  it('should be created', inject([MachinesService], (service: MachinesService) => {
    expect(service).toBeTruthy();
  }));
});
