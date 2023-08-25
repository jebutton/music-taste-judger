# music-taste-judger

## Version
Version 0.004.0
## Description
This is just a silly project I'm working on as I learn C# for my job, posted publicly with permission of my boss. 
I wanted to create something that isn't just an isolated language exercise when studying C#, especially since I need to learn unit testing in NUnit.
I come from a Java and Python background professionally, and I'm learning the nuances of C# as I go. It is definitely more than "Microsoft Java".
This tool is designed to judge your choice of Synthwave artist. I may expand it to more genres in the future.

***
## Eventual Goals:
- Loading JSON or XML that artist definitions are stored in.
- Writing tests for the tool using NUnit.

## Changelog
- 0.002.0 Created MusicalArtist class to hold information about an artist.
- 0.002.0 Replaced the big switch statement that was used for lookup of artists into a dictionary search.
- 0.002.0 Using the MusicalArtist class, creasted a methood to generate enough sample artists for development.
- 0.003.0 Changed Private Fields for the MusicalArtist class into public fields with acessor methods and private fields for internal use.
- 0.003.0 Implemented .Equals() and .GetHashCode().
- 0.004.0 Added ToString() method to the MusicalArtist Class
- 0.004.0 added the ability to read from a file of test json by implementing a class to create a Artist Dictionary.
- 0.004.0 Changed the constructor for the MusicalArtist class to work with Newtonsoft.Json.