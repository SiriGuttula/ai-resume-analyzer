import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-resume-analyzer',
  templateUrl: './resume-analyzer.component.html'
})
export class ResumeAnalyzerComponent {

  selectedFile: File | null = null;
  jobDescription = "";

  analysis: any = {};

  constructor(private http: HttpClient) {}

  onFileSelected(event: any) {
    this.selectedFile = event.target.files[0];
  }

  analyze() {

    if (!this.selectedFile) {
      alert("Upload resume first");
      return;
    }

    const formData = new FormData();
    formData.append("file", this.selectedFile);
    formData.append("jobDescription", this.jobDescription);

    this.http.post(
      "https://localhost:7115/api/resume/analyze",
      formData
    ).subscribe({
      next: (res:any) => {
        this.analysis = res;
      },
      error: (err) => {
        console.error(err);
        alert("Analysis failed");
      }
    });

  }
}