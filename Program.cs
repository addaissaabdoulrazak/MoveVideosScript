// The problem is there

/**
au niveau de mon disque dure D:\, j'ai un dossier "Ne confondez plus",
et qui à l'intérieur de celui ci j'ai un autre dossier nommer "video cours desordonnées", 
et qui à l'intérieur j'ai une dizaine de dossier temp et dans chaque dossier temps j'ai une vidéo. 
donne moi je code c# qui me permettre de déplacer chaqu'une des vidéo contenue dans les dfférents dossier temp, 
afin de placer ceux ci dans le dossier "NE confondez plus" ??
 */

//Translate English

/*
On my D:\ drive, i have a folder named "Ne confondez plus", inside which there is another folder named " "video cours desordonnées
Inside this folder, there are about ten "temp" folders, and each foldercontains a video
provide a C# Script that moves each video from the different "temp" folder and places them into the "Ne confondez plus" folder 🚀
 */

using System;

/**
au niveau de mon disque dure D:\, j'ai un dossier "Ne confondez plus",
et qui à l'intérieur de celui ci j'ai un autre dossier nommer "video cours desordonnées", 
et qui à l'intérieur j'ai une dizaine de dossier temp et dans chaque dossier temps j'ai une vidéo. 
donne moi je code c# qui me permettre de déplacer chaqu'une des vidéo contenue dans les dfférents dossier temp, 
afin de placer ceux ci dans le dossier "NE confondez plus" ??
 */
string destinationFolder = @"D:\\Ne confondez plus";
string sourceFolder = Path.Combine(destinationFolder, "video cours desordonnées");

if (!Directory.Exists(sourceFolder))
{
    Console.WriteLine("Le dossier source n'existe pas.");
    return;
}
// if you are a main directory and you would want to get all inside file(mp4) or 
string[] tempFolders = Directory.GetDirectories(sourceFolder); // retrieves all subfolders inside Cours désordonner.

foreach (var tempFolder in tempFolders) //Loop Through Each Subfolder
{
    /*
     * this below line retrieves all .mp4 video files from the tempFolder and stores their full paths in an array (videoFiles).
     * for exemple : 
     *  D:\Ne confondez plus\Cours désordonner\temp1\video1.mp4
        D:\Ne confondez plus\Cours désordonner\temp1\video2.mp4
        D:\Ne confondez plus\Cours désordonner\temp2\movie.mp4
        D:\Ne confondez plus\Cours désordonner\temp3\clip.mp4
     */

    string[] videoFiles = Directory.GetFiles(tempFolder, "*.mp4"); // updated according to the format of the videos

    foreach (var videoFile in videoFiles)
    {

        /**
         * what you should know !!!
         * 
         * Yes, Path.Combine() is used to construct a specific "file" or "folder" << path >> in a platform-independent way. 
         * => It ensures that directory separators (\ or /) are correctly placed based on the operating system.
         * 
         * ❌ What Could Be Improved?
         * The phrase "if you want to get a specific path" is a bit vague. Path.Combine() doesn’t "get" an existing path;
         * [it constructs a path by combining multiple parts.]
         */
        string destinationFile = Path.Combine(destinationFolder, Path.GetFileName(videoFile)); 

        int count = 1;
        while (File.Exists(destinationFile))
        {
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(videoFile);
            string extension = Path.GetExtension(videoFile);
            destinationFile = Path.Combine(destinationFolder, $"{fileNameWithoutExtension}_{count}{extension}");
            count++;
        }

        try
        {

            #region
            /*
             $$ if i understand that, it look like a change just  the path to a new path and "move" method make sure to remove the file from the source destination

            ✅ Yes! You got it!

            The File.Move(source, destination) method does two things:
            1️⃣ It changes the file's path to a new location.
            2️⃣ It removes the file from the original location after moving it.


            🔍 How Does It Work?
                Think of it as cutting and pasting a file:

                The source path (sourceFile) tells C# where the file currently is.
                The destination path (destinationFile) tells C# where to move it (with a new or same name).
                C# moves the file and deletes it from the original folder automatically.

               /// <summary>
               /// -Code here 
               /// 
                 🛠 Example: Moving a File Without Renaming

                  string sourceFile = @"D:\Ne confondez plus\Cours désordonner\temp1\video1.mp4";
                  string destinationFolder = @"D:\Ne confondez plus";

                   // Combine folder path with file name to move without renaming
                    
                    string destinationFile = Path.Combine(destinationFolder, Path.GetFileName(sourceFile));
                    File.Move(sourceFile, destinationFile);
                    Console.WriteLine($"Moved: {sourceFile} -> {destinationFile}");
             
                /// 
               /// </summary>
               /// 

            📌 Result:
                video1.mp4 is moved from
                👉 D:\Ne confondez plus\Cours désordonner\temp1\
                to
                👉 D:\Ne confondez plus\
                ✔ The original file is deleted from temp1.



             */

            #endregion

            #region
            /*
            🛠 Example: Moving and Renaming a File
            csharp
            Copy
            Edit

            string sourceFile = @"D:\Ne confondez plus\Cours désordonner\temp1\video1.mp4";
            string destinationFile = @"D:\Ne confondez plus\video8.mp4"; // New name

            File.Move(sourceFile, destinationFile);
            Console.WriteLine($"Moved and Renamed: {sourceFile} -> {destinationFile}");

            📌 Result:
            ✔ video1.mp4 is renamed to video8.mp4 while moving.
            ✔ The original file is deleted from temp1.



            💡 Key Takeaways

                ✔ File.Move(source, destination) changes the path & removes the original file.
                ✔ If destination includes a file name, the file is renamed during the move.
                ✔ If destination is a folder, you must use Path.Combine() to keep the same file name.


            */

            #endregion




            File.Move(videoFile, destinationFile);
            Console.WriteLine($"Déplacé: {videoFile} -> {destinationFile}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lors du déplacement de {videoFile}: {ex.Message}");
        }
    }
}

/*
 #Question : so if i understand, i can manipulate directely a file or a  video, i manipulate a path to manage this ??
 */