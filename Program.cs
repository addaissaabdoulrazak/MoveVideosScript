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

string destinationFolder = @"D:\\Ne confondez plus";
string sourceFolder = Path.Combine(destinationFolder, "video cours desordonnées");

if (!Directory.Exists(sourceFolder))
{
    Console.WriteLine("Le dossier source n'existe pas.");
    return;
}

string[] tempFolders = Directory.GetDirectories(sourceFolder); // retrieves all subfolders inside Cours désordonner.

foreach (var tempFolder in tempFolders)
{
    string[] videoFiles = Directory.GetFiles(tempFolder, "*.mp4"); // Modifier selon le format des vidéos

    foreach (var videoFile in videoFiles)
    {
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
            File.Move(videoFile, destinationFile);
            Console.WriteLine($"Déplacé: {videoFile} -> {destinationFile}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lors du déplacement de {videoFile}: {ex.Message}");
        }
    }
}