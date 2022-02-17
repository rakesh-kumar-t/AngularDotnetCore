import { TestBed } from '@angular/core/testing';

import { SharedapiService } from './sharedapi.service';

describe('SharedapiService', () => {
  let service: SharedapiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SharedapiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
