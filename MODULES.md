# Modules

## Structure

The general structure of a module consists of two projects. One project is there for providing the web-application interface of your module. The other is there for providing shared functionality that you might want to share to other modules.

An example would be the following:

* `BloodCore.Module.Example`
    * _Controllers, Views, etc..._
* `BloodCore.Module.Example.Shared`
    * _DataModels, Repositories, etc..._

## Quirks

### Razor views

Due to how **Visual Studio** works internally to provide functionality for **Razor**, you must take a few actions in order to get **Razor** views working for your module project.

#### Syntax highlighting

##### Symptom

    @model BloodCore.Module.Example.Shared.Models.Example
    
    The name 'model' does not exist in the current context

##### Solution

Copy `BloodCore.App\Views\web.config` into the `Views\` folder of your module project.

#### Intellisense

##### Symptom

    <h3>Hello, @Model.Name</h3>
    
    The name 'Model' does not exist in the current context

##### Solution

Change the `Output path` of your module project from `bin\Debug` and `bin\Release` to `bin\`.
