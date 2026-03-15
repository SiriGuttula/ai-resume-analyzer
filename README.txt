# AI Resume Analyzer

AI Resume Analyzer is a full-stack web application that analyzes a candidate’s resume against a job description using AI. The system provides insights such as resume score, job match score, detected skills, missing skills, and suggestions to improve the resume.

## Features

* Upload resume in PDF format
* Paste job description
* AI analyzes resume using GPT model
* Resume score calculation
* Job match score
* Skills detection
* Missing skills identification
* Resume improvement suggestions

## Tech Stack

Frontend

* Angular
* HTML
* CSS
* Bootstrap

Backend

* ASP.NET Core Web API
* C#

AI Integration

* OpenRouter API

Other Tools

* PdfPig for PDF text extraction
* Git and GitHub for version control

## Project Structure

AI-Resume-Analyzer
│
├── Frontend          # Angular UI
├── AIResumeScanner   # ASP.NET Core Web API
└── README.md

## How It Works

1. User uploads a resume in PDF format.
2. Backend extracts the text from the PDF using PdfPig.
3. The extracted resume text and job description are sent to the AI model.
4. The AI analyzes the data and generates structured results.
5. The Angular frontend displays the results including resume score, job match score, skills, missing skills, and improvements.

## Installation and Setup

### Backend (.NET API)

Navigate to the backend folder and run:

```
dotnet run
```

The API will start at:

```
https://localhost:7115
```

### Frontend (Angular)

Navigate to the frontend folder.

Install dependencies:

```
npm install
```

Run the Angular application:

```
ng serve
```
