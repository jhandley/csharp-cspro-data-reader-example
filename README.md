# csharp-cspro-data-reader-example
Simple example of reading a CSPro data file from a C# program using CSPro .NET API

This program reads a CSPro data file and writes the raw data to the console.

This projects illustrates the usage of .NET classes for reading CSPro dictionaries and data files. With CSPro version 7.1.3 and later there are dlls that expose .NET classes for working dictionaries and data files. To use these classes, add references to zDataCLR.dll and zDictCLR.dll to your project. These files can be found in the CSPro installation directory (usually C:\Program Files (x86)\CSPro 7.1). In addition, these DLLs have dependencies that are also in that directory. To load these DLLs, this project uses a custom AssemblyResolver to load them from the CSPro 7.1 installation directory. You may need to modify this if you are using a different installation directory or a different version of CSPro.

## Requirements
- Visual Studio 2017 or later
- .NET framework 4.5
- CSPro 7.1.3 or later

## Building
Open the solution in Visual Studio. If you have CSPro installed in a non-standard directory, update the references to zDataCLR and zDictCLR.

## Usage
datareader datafile [dictionary]

where *datafile* is the path to a CSPro data file in either text or csdb format and *dictionary* is an optional path to a CSPro data dictionary. *dictionary* is only required for data files in text format.





