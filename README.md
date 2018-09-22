# project002
c#
This project requires you to construct one application that will carry out two distinct functions.  
Write a Windows Forms application that satisfies the following behaviours:
1.	The user must be provided with a mechanism to select a folder.  This must be via a folder/file browse dialog box.  The system must support monitoring multiple folders.
2.	Provide a mechanism to remove folders from the list of folders being monitored; when done, you will need to remove all words that have been indexed in the files located in these folders (for indexing, see points 5 – 7 below).
3.	Your application should automatically collect all text files located in this folder.
4.	For each text file, your application should create an index of the words found, the location of each word and the name of the file in which that word was located.
5.	To optimise index search, you should ensure that certain words are ignored when you run your index creation code.  In other words, your system should maintain an ignore list or blacklist.  For this assignment, your ignore list must include the following words:  is, a, the, of, this, how, all, ago, I, me, he, he’ll, he’s, she, she’ll, she’s, am, in, so, is, be, let, mr, mrs, we, us, you, oh, ok and ex.  In addition, you must also not index 1 letter words.
6.	Your index needs to be saved as a binary file—think carefully about the structure of this binary file in terms of satisfying requirements.
7.	Your program must provide an index search feature.  Your application must provide a way for users to input a word to search for.  When the search is activated, all file names that match the given word must be displayed in a suitable way, e.g., a list box, combo box, etc.  Along with each file name you should provide some mechanism to show the location of searched for word within that file.
8.	When the user selects a given file name the associated file must be opened and the contents scrolled until the first instance of the searched for word is located.
9.	Your application must provide a reporting feature that enables the display of the following statistics:  total number of words indexed, the longest word indexed, the shortest word indexed, the most frequent word indexed and the least frequent.
10.	Your application must automatically index any text file that is placed or dropped into the directories that are being monitored.
11.	Any text file that is deleted from the directories that are being monitored must be removed from your index.
12.	The second piece of functionality that you must support is the ability to allow a user to enter a URL of a html page.
13.	When entered, your application must retrieve the html file and then process it, extracting only the <title> tag contents, the <a> anchor tag contents and <script> tag contents.  These should all be displayed appropriately.

