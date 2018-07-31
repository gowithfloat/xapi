#r "paket:
nuget Fake.IO.FileSystem
nuget Fake.Core.Target //"
#load "./.fake/build.fsx/intellisense.fsx"

open Fake.Core

// Default target
Target.create "Default" (fun _ ->
  // todo
)

// start build
Target.runOrDefault "Default"
