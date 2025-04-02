# Cybersecurity Awareness Chatbot

A console-based chatbot application designed to educate users about cybersecurity topics in South Africa.

## Project Overview

This chatbot provides information on essential cybersecurity topics including:
- Password safety
- Phishing awareness
- Safe browsing habits

The application features a voice greeting, ASCII art logo, and an interactive console interface with colored text and formatting.

## Features

- Voice greeting on startup
- ASCII art logo for visual identification
- User name personalization
- Colored text interface with borders and formatting
- Typing effect to simulate conversation
- Input validation
- Topic-based information delivery
- Help system

## Requirements

- .NET Core 3.1 or later
- Visual Studio 2019 or later (recommended)
- System.Media namespace support for playing WAV files

## Setup Instructions

1. Clone the repository to your local machine
2. Open the solution in Visual Studio
3. Build the solution to restore packages
4. Create a "greeting.wav" file with your voice message:
   - Record a brief welcome message: "Hello! Welcome to the Cybersecurity Awareness Bot. I'm here to help you stay safe online."
   - Save it as a WAV file named "greeting.wav"
   - Place the file in the project's output directory (bin/Debug/net{version})

## Running the Application

1. Build the solution
2. Run the application (F5 in Visual Studio)
3. The voice greeting will play automatically
4. Follow the on-screen prompts to navigate the chatbot

## GitHub Setup

1. Create a new repository on GitHub
2. Initialize the repository locally using:
   
   git init
   git add .
   git commit -m "Initial commit: Set up project structure and main files"
   git branch -M main
   git remote add origin [your-repo-url]
   git push -u origin main
   

3. Set up GitHub Actions for CI:
   - Create a .github/workflows directory
   - Add a YAML file for the workflow configuration
   - Configure the workflow to build and test the application

## Sample CI Workflow

Create a file at .github/workflows/dotnet.yml with the following content:

yaml
name: .NET Build and Test

on:
  push:
    branches: [ main ]
  pull_request:
    branches: [ main ]

jobs:
  build:
    runs-on: ubuntu-latest
    
    steps:
    - uses: actions/checkout@v2
    - name: Setup .NET
      uses: actions/setup-dotnet@v1
      with:
        dotnet-version: 6.0.x
    - name: Restore dependencies
      run: dotnet restore
    - name: Build
      run: dotnet build --no-restore
    - name: Test
      run: dotnet test --no-build --verbosity normal


## Submission Checklist

- [x] Complete console application with all required features
- [x] Voice greeting WAV file
- [x] ASCII art logo
- [x] GitHub repository with at least three commits
- [x] CI workflow setup with GitHub Actions
- [x] Screenshot of successful CI workflow run
- [x] Prepare for in-class code presentation

## License

This project is created for educational purposes as part of the Portfolio of Evidence.
