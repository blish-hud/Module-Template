# Blish HUD Module Template for Visual Studio 2019

[![](https://img.shields.io/badge/Release-ModuleTemplateDeployment.vsix-Blue)](https://github.com/blish-hud/Module-Template/releases)
[![Discord](https://img.shields.io/badge/Join_Our_Discord-📦module_discussion-Green)](https://discord.gg/HzAV82d)
[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2Fblish-hud%2FModule-Template.svg?type=shield)](https://app.fossa.com/projects/git%2Bgithub.com%2Fblish-hud%2FModule-Template?ref=badge_shield)

## Overview

This package, once installed, adds a new project type to Visual Studio 2019 to help with creating Blish HUD modules.

Instructions for creating a module without using this template can be found below.

You can review our [example module](https://github.com/blish-hud/Example-Blish-HUD-Module/blob/master/README.md) (note: the example module is somewhat outdated - the instructions below will be your best source when you are first getting started making a module).

## Module Workflow

Use either step A or step B below based on your preference.  Do not perform both sets of instructions.

### A. Setup Using the Module Template for Visual Studio 2019

1. Install the Visual Studio module template found under [Releases](https://github.com/blish-hud/Module-Template/releases).
2. Create a new project in Visual Studio using the template.
   - *Note: When doing this, you **must** select "Place solution and project in the same directory" while on the "Configure your new project" step of the project wizard.*
2. Run `nuget restore` in the Package Manager Console to ensure all NuGet packages are restored.

### B. Setup Without the Module Template

1. Create a new .NET Framework Class Library project.
2. Add a reference to the latest version of Blish HUD to your project (`Install-Package BlishHUD`).
   - *Note: Packages are currently marked as preleases.*
3. Ensure the Blish HUD and all dependent references have **Copy Local** set to **False** in the properties of the reference.
   - If you don't do this, your module will package these assemblies with your module.
     - This will make your modules unnecessarily large (it'll contain the entire Blish HUD assembly!).
     - Blish HUD will already have all of these assemblies loaded (since it naturally depends on them), so you don't need to include them.

### Update Your Manifest

1. Most importantly, ensure that the "package" attribute in your *manifest.json* matches your projects assembly name.  If this is not done, your module will fail to enable.
2. [Review the manifest format (currently v1)](https://github.com/blish-hud/manifest.json/blob/master/manifest-v1.md) for other manifest options.

If you have problems getting the "package" attribute correct, open your module's .bhm with a utility such as 7-Zip and check to see what the compiled .dll file is named inside of it.  This is what the value of your "package" attribute should be set to.

### Debugging Your Module

1. In your module's **Debug** settings, set the **Start action** to *Start external program* and specify the path of **Blish HUD.exe**.
2. Under the same settings, set **Command line arguments** to `--debug --module "c:\project-path\bin\x64\Debug\<path-to-your-module-output.bhm"`

By default, you should now be able to run your application - it'll generate the *.bhm* file automatically for you when the project is built.  The command line arguments you specified will launch Blish HUD and allow you to debug your module (the debugger will be attached).

As long as your project generates a PDB file, it will be packaged into your bhm and loaded by the module loader at runtime.

If your project contains references to assemblies that Blish HUD will not already have loaded, these will need to be copied locally (which is the default behavior) or embedded into your module assembly using ILMerge or Costura.Fody.  Assemblies that are copied locally will be packaged into the bhm and, when referenced by your module, Blish HUD will automatically attempt to load their assembly.


## License
[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2Fblish-hud%2FModule-Template.svg?type=large)](https://app.fossa.com/projects/git%2Bgithub.com%2Fblish-hud%2FModule-Template?ref=badge_large)