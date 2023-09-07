# Project Layout
The Medli operating system is made up of 4 main projects:

/Aryll - experimental stage of new features and bug fixes. This is built on the same .NET 6.0 that Medli and Makar are, 
but does not use any of the OS toolchain. It is only used for new features (which don't depend on OS-specific code or APIs directly) and bug fixes.
  
/Makar - staging area for new features and bug fixes, to iron out any incompatibilities  or deprecations within the 
operating system. For new features which depend on operating-system-specific code or APIs, this is the first stage of implementation. 
  
/Medli - The "stable" version of the operating system itself. As this is usually the final resting place of existing tested code,
this project is updated infrequently, only until testing has been carried out and approved to be merged.

/Medli.Plugs - This minimal project is used to override default implementations in the mainline OS toolchain. For example, exception handling, 
drivers and other implementations. This project doesn't reference Medli itself, but can be 'called' by the main Medli project.
  
/Licenses			- Contains the licenses for the framework, Dewitcher and Cosmos  

/Medli.sln			- The main solution file  
/Directories.md		- This file 
/README.md				- The readme  
  
