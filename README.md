# WRDL-Console
WRDL console is a variant of the popular word game Wordle. The game is a simple console application with a large word database that can be played as many times as you would like. This game was created because my coworkers wanted to play more than one round at a time.  
## Compatibility
WRDL Console is compatible with any Windows system with the .NET 6 runtime installed. 
## Contributions
WRDL Console is a working game, but it is also a work in progress. Any contributions are appreciated. 
## Future
Because this game was quickly developed, bug fixes and enhancements (such as a GUI) may be added in the future. Contributions are welcome.
## Known Issues
1. Because the word list was obtained from multiple sources there are some duplicates within the 100,000+ word XML file. There are also some strange words (or words that do not exist) within the list. Removing these will ensure that the player isn't faced with a word that they cannot guess. Building a better word list in the future, possibly using a more efficient method of storage, would be preferable. 
2. Resizing of the console window during gamelpay will disrupt the user interface. Forcing a resize and redraw upon window size change will eventually solve this issue. 
3. Users cannot currently copy and paste the end-game result because the coloration of the characters is bound to the console window itself. Populating the clipboard with the proper emjoi codes should resolve this. 
4. No game score is kept at this time
