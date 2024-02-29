
# EmployeeApp
Documentation




## Authors

- [@TomashTom](https://github.com/TomashTom)


## Installation
1 Step Clone repository

2 Step navigate into project directory 

3 Step
Start docker containers
```bash
  docker-compose up --build -d
```
## Usage
To create employee run command 

set-employee {index} {employee_name} {salary}

```bash
  e.g 

  docker-compose run app dotnet EmployeeApp.dll set-employee 12 Stefan 6969
```

To get employee use command

```bash
  e.g

  docker-compose run app dotnet EmployeeApp.dll get-employee 12 
```
