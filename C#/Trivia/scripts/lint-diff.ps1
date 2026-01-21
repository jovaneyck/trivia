# Get all changed files (staged and unstaged)
$changedFiles = git diff --name-only HEAD
$stagedFiles = git diff --cached --name-only

# Combine both sets of files and remove duplicates
$allChangedFiles = ($changedFiles + $stagedFiles) | Sort-Object -Unique

# Filter for C# files only
$csharpFiles = $allChangedFiles | Where-Object { $_ -match '\.(cs|csx)$' }

if ($csharpFiles.Count -eq 0) {
    Write-Host "No C# files have been changed." -ForegroundColor Yellow
    exit 0
}

Write-Host "Found $($csharpFiles.Count) changed C# file(s):" -ForegroundColor Green
$csharpFiles | ForEach-Object { Write-Host "  $_" -ForegroundColor Cyan }

# Convert git paths to local paths and run csharpier on each file
Write-Host "`nFormatting changed files..." -ForegroundColor Green
foreach ($file in $csharpFiles) {
    # Convert git repository relative path to current directory relative path
    $localPath = $file -replace "^C#/Trivia/", ""
    if (Test-Path $localPath) {
        Write-Host "Formatting: $localPath" -ForegroundColor Gray
        dotnet csharpier format $localPath
    } else {
        Write-Host "Warning: File not found at $localPath" -ForegroundColor Yellow
    }
}