import { Component, Input, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.css']
})
export class FilterComponent implements OnInit {

  selected:string = "id";
  value:string = 'Search me';
  newDataSource !: MatTableDataSource<any>;

  @Input() dataSource !: MatTableDataSource<any>;

  constructor() { }

  ngOnInit(): void {
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  filterPeople(value:string){
    //console.log("Buscar->",value);
    //console.log("dataSource->",this.dataSource.filteredData[0].id);

    this.dataSource.filteredData.forEach(element => {

      switch (this.selected) {
        case "id":
          if(element.id == value){
            console.log(element);
            // this.newDataSource = new MatTableDataSource(element);
          }
          break;
          
        case "firstName":
          if(element.name1 == value){
            console.log(element);
            // this.newDataSource = new MatTableDataSource(element);
          }
          break;

        case "firstLastname":
          if(element.lastname1 == value){
            console.log(element);
          }
          break;
            
        case "email":
          if(element.email == value){
            console.log(element);
          }
          break;
      }
            
      
    });
    
    // this.dataSource = this.newDataSource;
    // console.log("New-->", this.dataSource);
    
  }

}
