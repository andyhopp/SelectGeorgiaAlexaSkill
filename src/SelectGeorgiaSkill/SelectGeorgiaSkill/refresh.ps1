dotnet publish
& 'C:\Program Files\7-Zip\7z.exe' "-x!*.zip" a .\bin\Debug\netcoreapp1.1\publish\SelectGeorgiaSkill.zip .\bin\Debug\netcoreapp1.1\publish\*
aws lambda update-function-code --function-name SelectGeorgiaSkillHandler --zip-file fileb://.\bin\Debug\netcoreapp1.1\publish\SelectGeorgiaSkill.zip