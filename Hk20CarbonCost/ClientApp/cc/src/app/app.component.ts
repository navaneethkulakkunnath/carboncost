import { Component, OnInit } from '@angular/core';
import { AppState } from './app.service';
declare var $: any; 
declare var jQuery: any; 
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'cc';
  public fromAccountList: any;
  public toAccountList: any;
  public categoryList: any;
  public fromAccount = '';
  public toAccount = '';
  public categoryName; 
  public carbonCostPercentage = '0';
  constructor(private appState:AppState ) { }
  public amount = '';
  public carbonCostAmount;
  public totalAmount = 0;

  ngOnInit() {
    this.loadFromAccountList();
    this.loadToAccountList();
    this.loadRemarks();
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
   loadRemarks() {
    this.appState.emissionCategory().subscribe(data => { 
     this.categoryList = data;
    });
   }
   fetchCarbonCost(categoryId) {
     if(categoryId){
      let selectedCategory = this.categoryList.filter(data => data.name == categoryId);
      if(selectedCategory && selectedCategory[0]){
      this.carbonCostPercentage = selectedCategory[0].fee;
      this.appState.calculate(this.amount,categoryId).subscribe(data => { 
      this.carbonCostAmount = data;
      this.totalAmount = parseFloat(this.amount) + parseFloat(this.carbonCostAmount);
        });
      }
     }
   }
}
