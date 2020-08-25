import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { JobService } from '../services/job.service';
import { JobModel } from '../models/job.model';
import { CustomerType } from '../models/customerType';

@Component({
  selector: 'app-job-detail',
  templateUrl: './job-detail.component.html',
  styleUrls: ['./job-detail.component.scss']
})
export class JobDetailComponent implements OnInit {

  private jobId: number;

  public job: JobModel;
  public CustomerType = CustomerType;

  constructor(
    private route: ActivatedRoute,
    private jobService: JobService) {
      this.jobId = route.snapshot.params.id;
    }

  ngOnInit() {
    this.jobService.GetJob(this.jobId).subscribe(job => this.job = job);
  }

}
