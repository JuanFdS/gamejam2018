# gamejam2018

#Para evitar conflictos con la escena: agregar al .git/config lo siguiente:

[mergetool "unityyamlmerge"]
	trustExitCode = false
	keepTemporaries = true
	keepBackup = false
	path = 'C:\\Program Files\\Unity\\Editor\\Data\\Tools\\UnityYAMLMerge.exe'
	cmd = 'C:\\Program Files\\Unity\\Editor\\Data\\Tools\\UnityYAMLMerge.exe' merge -p "$BASE" "$REMOTE" "$LOCAL" "$MERGED"
