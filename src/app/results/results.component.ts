import { Component, OnInit} from '@angular/core';
import { ITestResults } from '../interfaces/ITestResults';
import {MatTableDataSource} from '@angular/material/table';
import {ResultsService} from "./results.service";


@Component({
  selector: 'app-results',
  templateUrl: './results.component.html',
  styleUrls: ['./results.component.css']
})
export class ResultsComponent implements OnInit{

  columns: string[] = ["student", "subject", "score", "grade"]
  results_data: ITestResults[] = []
  dataSource = new MatTableDataSource<ITestResults>

  constructor(private resultsService: ResultsService) {
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  GetResults(){
    let token = localStorage.getItem('token')
    this.resultsService.AllResults(token!)
      .subscribe(results => {
        this.results_data = results
        this.dataSource.data = this.results_data
      })
  }

  ngOnInit(): void {
    this.GetResults()
  }
}
