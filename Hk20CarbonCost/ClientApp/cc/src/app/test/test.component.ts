import { Component, OnInit } from '@angular/core';
import { AppState } from '../app.service';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.scss']
})
export class TestComponent implements OnInit {

  public fromAccountList: any;
  public toAccountList: any;
  constructor(private appState:AppState ) { }

  ngOnInit(): void {
    this.loadFromAccountList();
    this.loadToAccountList();
  }
  loadFromAccountList() {
   this.appState.fromAccountList().subscribe(data => { 
    this.fromAccountList = data;
   });
  }
  loadToAccountList() {
    this.appState.toAccountList().subscribe(data => {
      this.toAccountList = data;
    });
   }
}
