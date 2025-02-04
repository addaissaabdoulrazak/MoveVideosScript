This C# console application scans a specified folder (Cours désordonner), finds video files inside its subdirectories, and moves them into a target folder (Ne confondez plus). If a file with the same name already exists, it automatically renames the new file to prevent overwriting.

Features:
✔ Scans multiple subfolders for videos (.mp4, customizable)

✔ Moves videos to a single target directory

✔ Handles duplicate filenames by renaming them

✔ Error handling for missing folders or permissions

---
---

==>  #Question : so if i understand, i can manipulate directely a file or a  video, i manipulate a path to manage this ??

Exactly! 🎯

In C#, when you work with files (like videos), you don’t manipulate the file directly—instead, you manipulate its path to manage it.

🔍 Why Do You Work with Paths Instead of Files Directly?

1️⃣ A file is just data stored on disk.

2️⃣ A path is the way to access that file.

3️⃣ C# file operations (File.Move(), File.Copy(), File.Delete()) use paths to locate and manipulate files.

----

#Code Exampl 

📌 Example: Moving a Video File

string sourcePath = @"D:\Ne confondez plus\Cours désordonner\temp1\video1.mp4";

string destinationPath = @"D:\Ne confondez plus\video1.mp4";

File.Move(sourcePath, destinationPath);

➡ Here, you are NOT moving the file itself.

➡ You are telling C# “Move the file located at sourcePath to destinationPath”.

📌 Example: Renaming a File

You cannot rename a file directly, but you can change its path with File.Move():


string oldPath = @"D:\Ne confondez plus\video1.mp4";

string newPath = @"D:\Ne confondez plus\video1_renamed.mp4";

File.Move(oldPath, newPath);

✅ The file is renamed because its new path has a different name.

---

📌 Example: Checking If a File Exists

Before moving or renaming a file, you should check if it exists using the file path:


if (File.Exists(sourcePath))
{
    File.Move(sourcePath, destinationPath);
}
else
{
    Console.WriteLine("File does not exist!");
}


✔ You’re checking the existence of the file via its path, not the file itself.

✅ Conclusion: You Manage Paths, Not Files Directly


✔ A file is data on disk.

✔ A path is the way you locate and manipulate a file.

✔ Every file operation (Move, Copy, Delete) is done using paths.

Would you like to add file validation before moving them? 🚀

---

✅ Correct Part

Yes, Path.Combine() is used to construct a specific file or folder path in a platform-independent way. It ensures that directory separators (\ or /) are correctly placed based on the operating system.

❌ What Could Be Improved?

The phrase "if you want to get a specific path" is a bit vague. Path.Combine() doesn’t "get" an existing path; it constructs a path by combining multiple parts.

Better Comment Suggestion:

// Use Path.Combine() to safely construct a file or folder path.

Or

// Path.Combine() joins multiple path segments into a valid file path.


Here are some examples of how Path.Combine() works:

NB: Follow these steps // the steps below

1️⃣ Basic Example (Joining Folder and File)

string folder = @"C:\Users\John\Documents";

string fileName = "report.pdf";

string fullPath = Path.Combine(folder, fileName);

Console.WriteLine(fullPath);  
// Output: C:\Users\John\Documents\report.pdf

✅ Path.Combine() ensures that the folder and file are properly joined with \.


2️⃣ Joining Multiple Folders

string part1 = @"C:\Users";

string part2 = "John";

string part3 = "Desktop";

string fullPath = Path.Combine(part1, part2, part3);

Console.WriteLine(fullPath);  
// Output: C:\Users\John\Desktop

✅ You can combine multiple path segments at once.

3️⃣ Avoiding Incorrect Separators

string folder = @"C:\Users\John\Documents\";  // Has trailing backslash

string file = "notes.txt";

string fullPath = Path.Combine(folder, file);

Console.WriteLine(fullPath);  
// Output: C:\Users\John\Documents\notes.txt  ✅ (No double `\\`)

✅ Even if folder ends with \, Path.Combine() avoids duplicate slashes.


4️⃣ Example from Your Code

string destinationFolder = @"D:\Ne confondez plus";

string videoFileName = "video1.mp4";

string destinationFile = Path.Combine(destinationFolder, videoFileName);

Console.WriteLine(destinationFile);
// Output: D:\Ne confondez plus\video1.mp4

✅ This is how your script correctly builds the destination file path before moving videos.

Let me know if you need more examples! 🚀



