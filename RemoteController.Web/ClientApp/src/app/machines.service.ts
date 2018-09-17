import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from "rxjs/Observable";
import { Machine } from "./models/machine"

@Injectable()
export class MachinesService {

  constructor(private httpClient: HttpClient) { }

  getMachines(): Observable<Machine[]> {
    return this.httpClient.get<Machine[]>('/api/Machines');
  }
}
