# Scheduler

Ready to use, .NET MVC based, weekly scheduler for trainings.

## Application Introduction

Scheduler will be responsible for managing personal trainings (when and who will be on the training )

## System Requirements
- Web-based application
- Performs CRUD operations on the trainings

##  Non-Functional Requirements
- Classic data-driven 
- There are not a lot of users
- Not a mission-critical system

### Questions SA needs to ask:
- “How many concurrent users do you expect?”
- “How many trainings are you going to manage?”

And these are the answers we got from the clients:
- 10 concurrent users. It should not be a problem.
- 250 training. Not an issue. 

### Data Volume
Estimate the total size of the data the system should be able to store.

Each training holds around 1 MB of data. On top of that, the company stores around 10 scanned documents for every training – contracts, reviews, etc. 
One document is around five megabytes, so the total data for one training is:
5 MB x 10 + 1 MB = 51 MB
The company has 250 trainings currently, but long term expects 500 trainings in five years. 
The total storage:
51 MB x 500 Trainings = 25.5 GB (relational & unstructured)

## Continuous Integration Tools
- GitHub Pipelines
![GitHubBuildStatus](https://github.com/profjordanov/scheduler/actions/workflows/main.yml/badge.svg)

- Travis CI 
[![TravisBuildStatus](https://travis-ci.com/profjordanov/scheduler.svg?branch=main)](https://travis-ci.com/profjordanov/scheduler)

## Screens

- Home

![home-screeen](./Scheduler.Docs/Home.JPG)

- Home on mobile

![Home-on-phone](./Scheduler.Docs/Home-on-phone.JPG)

- Create

![create](./Scheduler.Docs/create.JPG)
