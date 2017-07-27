Learning Games is a Windows application for teaching reading and arithmetic to children. It currently consists of two basic games:

* KeyWords game - presents randomly selected words for a child to read out, while the parent indicates whether they got it right or not
* Numbers game - presents randomly generated sums to be solved

Learning Games has not yet been released. I intend to make the games more configurable, and to present and persist results before the first version is made public.

Learning Games has also been an opportunity for me to learn and make use of the following technologies and development methodologies. I welcome feedback on how things could be done better, as well as any volunteers wanting to help with this project.

* WPF - the game currently runs using the .NET 3.5 framework on Windows. 
* Silverlight - A Silverlight 4 version has now been created, although some compromises had to be made to get this working
* MVVM - using data binding for all communications between View and Model. This is enabled by a selection of helper attached dependency properties.
* MEF - new games can be added easily by creating a new DLL and implementing an interface. Am looking in to using it instead of an IoC container as well.
* NUnit and Moq - I am trying to write as much new code as possible with TDD
