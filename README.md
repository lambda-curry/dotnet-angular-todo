# Todo List Interview Question

This project is meant to be an interview where

## Setting up your development environment

This project requires you to have the following installed on your machine.

- Docker
- Yarn
- dotnet core cli

If you are using OSX or a linux based operating system, you can use the Makefile to run `make` in the terminal. This will spin up a mariadb docker container, start the .NET api and start the angular frontend.

If you are not using a linux/unix based operating system (ex: Windows/DOS), you should be able to use the following commands to start the app.

- Run `docker-compose up -d` in powershell or git bash. This will start a mariadb database using docker.
- Run `dotnet restore` inside the `api` directory. This will install the C# dependencies needed to run the api.
- Then `dotnet run` inside the `api` directory. This will start the api server.
- Inside another git bash or powershell directory, go to the `frontend` directory and run `yarn`.
- Run `yarn start` in the `frontend` directory.

You will know everything is running correctly when you go to http://localhost:4200 in your browser, and see a todo list with 3 todos.

## Development

We recommend using Visual Studio Code to do your active development, but you can use whatever code editor you would like. To help, here are some good Visual Studio Code extensions we recommend.

- C# https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp
- Code Spell Checker https://marketplace.visualstudio.com/items?itemName=streetsidesoftware.code-spell-checker
- Better Comments https://marketplace.visualstudio.com/items?itemName=aaron-bond.better-comments
- Prettier - Code formatter https://marketplace.visualstudio.com/items?itemName=esbenp.prettier-vscode
- Visual Studio IntelliCode https://marketplace.visualstudio.com/items?itemName=VisualStudioExptTeam.vscodeintellicode
- TSLint https://marketplace.visualstudio.com/items?itemName=ms-vscode.vscode-typescript-tslint-plugin
- NuGet Package Manager https://marketplace.visualstudio.com/items?itemName=jmrog.vscode-nuget-package-manager

## Coding Question Requirements

This project includes the scaffolding for a todo app written using Angular 11 and dotnet core 3.0. Our ask is that you finish building the todo app.

There are 3 api endpoints that need to be wired up in the api. Create, Update, and Delete. These will test your C#/dotnet and SQL skills. You can use the scaffolding provided in the `TodoService.cs`

The end goal is to have a TODO app that:

- Only shows uncompleted todos ordered by created date descending.
- Has a functioning delete button that will delete the todo in the database and in the list.
- Has a functioning "done" checkbox that will complete the todo and update it in the database.
- Has a way to create a new todo. Consider using a mat-dialog with an input.

BONUS goals:

- Add a way to show completed todos.
- Add a way to search for todos by title.

If you get stuck getting your development environment setup, reach out to derek@lambdacurry.dev
