  name: .NET CI - Build and Test

on:
  push:
    branches: [ main ]
  pull_request:
    branches: [ main ]

jobs:
  build:
    runs-on: windows-latest  # WPF applications must be built on a Windows runner

    steps:
    - name: Checkout repository code
      uses: actions/checkout@v3

    - name: Setup .NET SDK
      uses: actions/setup-dotnet@v3
      with:
        dotnet-version: '6.0.x' # Using .NET 6 as a standard, adjust if needed

    - name: Restore NuGet packages
      run: dotnet restore ./ProjectRoomManager.sln

    - name: Build the solution
      run: dotnet build ./ProjectRoomManager.sln --configuration Release --no-restore

    - name: Run unit tests
      run: dotnet test ./ProjectRoomManager.sln --no-build --verbosity normal
