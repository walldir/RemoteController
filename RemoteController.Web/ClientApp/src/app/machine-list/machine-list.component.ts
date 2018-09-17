import { Component, OnInit } from '@angular/core';

import { MachinesService } from '../machines.service';
import { Machine } from '../models/machine'

@Component({
  selector: 'app-machine-list',
  templateUrl: './machine-list.component.html',
  styleUrls: ['./machine-list.component.css']
})
export class MachineListComponent implements OnInit {
  public machines: Machine[];

  constructor(private machinesService: MachinesService) { }

  ngOnInit() {
    this.machinesService.getMachines()
      .subscribe(machines => {
        this.machines = machines;
      });
  }
}
