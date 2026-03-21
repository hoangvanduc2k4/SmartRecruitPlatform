$paths = @('SmartRecruit.Infrastructure/Migrations/ApplicationDbContextModelSnapshot.cs', 'SmartRecruit.Infrastructure/Migrations/20260321114811_InitialVietnameseLocal_V2.Designer.cs')

foreach ($path in $paths) {
    if (-Not (Test-Path $path)) { continue }
    $content = Get-Content $path
    $newContent = New-Object System.Collections.Generic.List[string]
    $keep = $true

    foreach ($line in $content) {
        if ($line -match '^<<<<<<< HEAD') {
            $keep = $true
            continue
        }
        if ($line -match '^=======') {
            $keep = $false
            continue
        }
        if ($line -match '^>>>>>>> master') {
            $keep = $true
            continue
        }
        if ($keep) {
            $newContent.Add($line)
        }
    }

    $newContent | Set-Content $path
}
