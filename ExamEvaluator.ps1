# OOP Final Term Exam Evaluator
# Evaluates student implementations against README requirements
# Total Score: 50 points
param(
    [string]$ProjectPath = $PSScriptRoot
)

$Score = 0
$MaxScore = 50
$Rubric = @()

function Add-Rubric {
    param(
        [string]$Category,
        [int]$Points,
        [string]$Status,
        [string]$Comment
    )
    
    $Script:Rubric += [PSCustomObject]@{
        Category = $Category
        Points = $Points
        Status = $Status
        Comment = $Comment
    }
    
    if ($Status -eq "[PASS]") {
        $Script:Score += $Points
    } elseif ($Status -eq "[PARTIAL]") {
        $Script:Score += [math]::Floor($Points * 0.5)
    }
}

function Check-FileExists {
    param([string]$FilePath)
    return Test-Path -Path $FilePath
}

function Get-FileContent {
    param([string]$FilePath)
    if (Test-Path -Path $FilePath) {
        return Get-Content -Path $FilePath -Raw
    }
    return $null
}

function Check-ClassInheritance {
    param(
        [string]$Content,
        [string]$ClassName,
        [string]$BaseClass
    )
    
    $pattern = "class\s+$ClassName\s*:\s*$BaseClass"
    return $Content -match $pattern
}

function Check-PropertyExists {
    param(
        [string]$Content,
        [string]$PropertyName,
        [string]$PropertyType = ""
    )
    
    if ($PropertyType) {
        $pattern = "public\s+$PropertyType\s+$PropertyName\s*\{\s*get;\s*set;\s*\}"
    } else {
        $pattern = "$PropertyName\s*\{\s*get;\s*set;\s*\}"
    }
    
    return $Content -match $pattern
}

function Check-MethodImplementation {
    param(
        [string]$Content,
        [string]$MethodName,
        [string[]]$RequiredCode
    )
    
    if (-not ($Content -match "public.*$MethodName\s*\(")) {
        return $false
    }
    
    foreach ($code in $RequiredCode) {
        # Check if code exists but NOT as a comment
        # First check if code exists at all
        if (-not ($Content -match [regex]::Escape($code))) {
            return $false
        }
        
        # Now check if it's commented out - if ALL occurrences are commented, fail
        $lines = $Content -split "`n"
        $hasUncommentedCode = $false
        
        foreach ($line in $lines) {
            $trimmedLine = $line.Trim()
            
            # Skip empty lines
            if ([string]::IsNullOrWhiteSpace($trimmedLine)) {
                continue
            }
            
            # If line contains the code and is NOT commented, mark as found
            if (($trimmedLine -match [regex]::Escape($code)) -and -not ($trimmedLine.StartsWith("//") -or $trimmedLine.StartsWith("#"))) {
                $hasUncommentedCode = $true
                break
            }
        }
        
        if (-not $hasUncommentedCode) {
            return $false
        }
    }
    
    return $true
}

function Check-CommentedImplementation {
    param(
        [string]$Content,
        [string]$MethodName,
        [string[]]$RequiredCode
    )
    
    # Check if there's commented code with the required implementation
    foreach ($code in $RequiredCode) {
        if (-not ($Content -match "//\s*" + [regex]::Escape($code))) {
            return $false
        }
    }
    
    return $true
}

function Check-FormControls {
    param([string]$Content)
    
    # Exclude buttons from evaluation as per requirements
    $controls = @("txtFirstName", "txtLastName", "txtGenres", "numTotalMovies")
    $found = 0
    
    foreach ($control in $controls) {
        if ($Content -match $control) {
            $found++
        }
    }
    
    return @{
        Total = $controls.Count
        Found = $found
    }
}

# ==================== EVALUATION START ====================
Write-Host "`n===== OOP Final Term Exam Evaluator =====" -ForegroundColor Cyan
Write-Host "Project Path: $ProjectPath`n" -ForegroundColor Yellow

# ==================== STEP 1: PersonModel ====================
Write-Host "Step 1: Checking PersonModel..." -ForegroundColor Magenta

$personModelPath = Join-Path $ProjectPath "OOP.FinalTerm.Exam\Model\PersonModel.cs"
$personModelExists = Check-FileExists -FilePath $personModelPath

if ($personModelExists) {
    $personContent = Get-FileContent -FilePath $personModelPath
    
    # Check if class exists
    if ($personContent -match "class\s+PersonModel") {
        # Check required properties
        $hasId = Check-PropertyExists -Content $personContent -PropertyName "Id"
        $hasFirstName = Check-PropertyExists -Content $personContent -PropertyName "FirstName"
        $hasLastName = Check-PropertyExists -Content $personContent -PropertyName "LastName"
        
        if ($hasId -and $hasFirstName -and $hasLastName) {
            Add-Rubric -Category "PersonModel Class" -Points 5 -Status "[PASS]" -Comment "Class exists with all required properties"
        } else {
            Add-Rubric -Category "PersonModel Class" -Points 5 -Status "[PARTIAL]" -Comment "Class exists but missing some properties"
        }
        
        # Check for SQLite attributes
        if ($personContent.Contains("[PrimaryKey") -and $personContent.Contains("AutoIncrement")) {
            Add-Rubric -Category "PersonModel SQLite Attributes" -Points 2 -Status "[PASS]" -Comment "SQLite attributes properly applied"
        } else {
            Add-Rubric -Category "PersonModel SQLite Attributes" -Points 2 -Status "[FAIL]" -Comment "Missing PrimaryKey and/or AutoIncrement attributes"
        }
    } else {
        Add-Rubric -Category "PersonModel Class" -Points 5 -Status "[FAIL]" -Comment "PersonModel class not found"
        Add-Rubric -Category "PersonModel SQLite Attributes" -Points 2 -Status "[FAIL]" -Comment "Cannot check - class not found"
    }
} else {
    Add-Rubric -Category "PersonModel File" -Points 7 -Status "[FAIL]" -Comment "File not created at $personModelPath"
}

# ==================== STEP 2: DirectorModel ====================
Write-Host "Step 2: Checking DirectorModel..." -ForegroundColor Magenta

$directorModelPath = Join-Path $ProjectPath "OOP.FinalTerm.Exam\Model\DirectorModel.cs"
$directorModelExists = Check-FileExists -FilePath $directorModelPath

if ($directorModelExists) {
    $directorContent = Get-FileContent -FilePath $directorModelPath
    
    # Check inheritance
    if (Check-ClassInheritance -Content $directorContent -ClassName "DirectorModel" -BaseClass "PersonModel") {
        Add-Rubric -Category "DirectorModel Inheritance" -Points 3 -Status "[PASS]" -Comment "Properly inherits from PersonModel"
    } else {
        Add-Rubric -Category "DirectorModel Inheritance" -Points 3 -Status "[FAIL]" -Comment "Does not inherit from PersonModel"
    }
    
    # Check properties
    $hasGenres = Check-PropertyExists -Content $directorContent -PropertyName "Genres"
    $hasTotalMovies = Check-PropertyExists -Content $directorContent -PropertyName "TotalMoviesCreated"
    
    if ($hasGenres -and $hasTotalMovies) {
        Add-Rubric -Category "DirectorModel Properties" -Points 3 -Status "[PASS]" -Comment "Has Genres and TotalMoviesCreated properties"
    } elseif ($hasGenres -or $hasTotalMovies) {
        Add-Rubric -Category "DirectorModel Properties" -Points 3 -Status "[PARTIAL]" -Comment "Missing one required property"
    } else {
        Add-Rubric -Category "DirectorModel Properties" -Points 3 -Status "[FAIL]" -Comment "Missing both required properties"
    }
} else {
    Add-Rubric -Category "DirectorModel File" -Points 6 -Status "[PARTIAL]" -Comment "DirectorModel.cs may not be fully implemented"
}

# ==================== STEP 3: DirectorRepository ====================
Write-Host "Step 3: Checking DirectorRepository..." -ForegroundColor Magenta

$repoPath = Join-Path $ProjectPath "OOP.FinalTerm.Exam\Repository\DirectorRepository.cs"
$repoExists = Check-FileExists -FilePath $repoPath

if ($repoExists) {
    $repoContent = Get-FileContent -FilePath $repoPath
    
    # Check constructor - check for commented code first, then uncommented
    if ($repoContent -match "//\s*_dbConnection\s*=\s*new\s*SQLiteConnection" -or $repoContent -match "//.*CreateTable") {
        Add-Rubric -Category "DirectorRepository Constructor" -Points 3 -Status "[FAIL]" -Comment "Constructor code is commented out"
    } elseif ($repoContent -match "^\s*_dbConnection\s*=\s*new\s*SQLiteConnection" -and $repoContent -match "^\s*_dbConnection\.CreateTable") {
        Add-Rubric -Category "DirectorRepository Constructor" -Points 3 -Status "[PASS]" -Comment "Database connection initialized"
    } else {
        Add-Rubric -Category "DirectorRepository Constructor" -Points 3 -Status "[FAIL]" -Comment "Constructor not properly implemented"
    }
    
    # Check AddDirector method
    if (Check-MethodImplementation -Content $repoContent -MethodName "AddDirector" -RequiredCode @("Insert")) {
        Add-Rubric -Category "DirectorRepository AddDirector()" -Points 3 -Status "[PASS]" -Comment "Method uses Insert() correctly"
    } elseif (Check-CommentedImplementation -Content $repoContent -MethodName "AddDirector" -RequiredCode @("Insert")) {
        Add-Rubric -Category "DirectorRepository AddDirector()" -Points 3 -Status "[PARTIAL]" -Comment "Implementation is commented - needs to be uncommented"
    } else {
        Add-Rubric -Category "DirectorRepository AddDirector()" -Points 3 -Status "[FAIL]" -Comment "Method not implemented or incomplete"
    }
    
    # Check GetAllDirectors method
    if (Check-MethodImplementation -Content $repoContent -MethodName "GetAllDirectors" -RequiredCode @("Table", "ToList")) {
        Add-Rubric -Category "DirectorRepository GetAllDirectors()" -Points 3 -Status "[PASS]" -Comment "Method uses Table().ToList() correctly"
    } elseif (Check-CommentedImplementation -Content $repoContent -MethodName "GetAllDirectors" -RequiredCode @("Table", "ToList")) {
        Add-Rubric -Category "DirectorRepository GetAllDirectors()" -Points 3 -Status "[PARTIAL]" -Comment "Implementation is commented - needs to be uncommented"
    } else {
        Add-Rubric -Category "DirectorRepository GetAllDirectors()" -Points 3 -Status "[FAIL]" -Comment "Method not implemented or incomplete"
    }
    
    # Check GetDirectorById method
    if (Check-MethodImplementation -Content $repoContent -MethodName "GetDirectorById" -RequiredCode @("Find")) {
        Add-Rubric -Category "DirectorRepository GetDirectorById()" -Points 3 -Status "[PASS]" -Comment "Method uses Find() correctly"
    } elseif (Check-CommentedImplementation -Content $repoContent -MethodName "GetDirectorById" -RequiredCode @("Find")) {
        Add-Rubric -Category "DirectorRepository GetDirectorById()" -Points 3 -Status "[PARTIAL]" -Comment "Implementation is commented - needs to be uncommented"
    } else {
        Add-Rubric -Category "DirectorRepository GetDirectorById()" -Points 3 -Status "[FAIL]" -Comment "Method not implemented or incomplete"
    }
} else {
    Add-Rubric -Category "DirectorRepository Methods" -Points 12 -Status "[FAIL]" -Comment "Repository file not found or not implemented"
}

# ==================== STEP 4: DirectorForm ====================
Write-Host "Step 4: Checking DirectorForm..." -ForegroundColor Magenta

$formPath = Join-Path $ProjectPath "OOP.FinalTerm.Exam\Views\DirectorForm.cs"
$formDesignerPath = Join-Path $ProjectPath "OOP.FinalTerm.Exam\Views\DirectorForm.Designer.cs"
$formExists = Check-FileExists -FilePath $formPath
$designerExists = Check-FileExists -FilePath $formDesignerPath

if ($formExists -and $designerExists) {
    $formContent = Get-FileContent -FilePath $formPath
    $designerContent = Get-FileContent -FilePath $formDesignerPath
    
    # Check form controls in Designer file (where they are actually declared)
    $controlsStatus = Check-FormControls -Content $designerContent
    
    if ($controlsStatus.Found -eq $controlsStatus.Total) {
        Add-Rubric -Category "DirectorForm Controls" -Points 3 -Status "[PASS]" -Comment "All required form controls found ($($controlsStatus.Found)/$($controlsStatus.Total))"
    } elseif ($controlsStatus.Found -ge 2) {
        Add-Rubric -Category "DirectorForm Controls" -Points 3 -Status "[PARTIAL]" -Comment "Found $($controlsStatus.Found)/$($controlsStatus.Total) controls - missing some"
    } else {
        Add-Rubric -Category "DirectorForm Controls" -Points 3 -Status "[FAIL]" -Comment "Only found $($controlsStatus.Found)/$($controlsStatus.Total) controls"
    }
    
    # Check GetDirector method
    if (Check-MethodImplementation -Content $formContent -MethodName "GetDirector" -RequiredCode @("txtFirstName", "FirstName", "return")) {
        Add-Rubric -Category "DirectorForm GetDirector()" -Points 3 -Status "[PASS]" -Comment "Maps form controls to director properties"
    } else {
        Add-Rubric -Category "DirectorForm GetDirector()" -Points 3 -Status "[FAIL]" -Comment "Method not properly implemented"
    }
    
    # Check validation in BtnSave_Click - must be uncommented
    if (Check-MethodImplementation -Content $formContent -MethodName "BtnSave_Click" -RequiredCode @("IsNullOrWhiteSpace", "MessageBox.Show")) {
        Add-Rubric -Category "DirectorForm Validation" -Points 3 -Status "[PASS]" -Comment "Form validation implemented"
    } else {
        Add-Rubric -Category "DirectorForm Validation" -Points 3 -Status "[FAIL]" -Comment "Validation not implemented"
    }
} else {
    Add-Rubric -Category "DirectorForm Implementation" -Points 9 -Status "[FAIL]" -Comment "Form file not found or not implemented"
}

# ==================== STEP 5: SettingsForm ====================
Write-Host "Step 5: Checking SettingsForm LoadDirectorsToGrid()..." -ForegroundColor Magenta

$settingsPath = Join-Path $ProjectPath "OOP.FinalTerm.Exam\Views\SettingsForm.cs"
$settingsExists = Check-FileExists -FilePath $settingsPath

if ($settingsExists) {
    $settingsContent = Get-FileContent -FilePath $settingsPath
    
    # Check LoadDirectorsToGrid method - must be uncommented
    if (Check-MethodImplementation -Content $settingsContent -MethodName "LoadDirectorsToGrid" -RequiredCode @("GetAllDirectors", "dgvDirectors")) {
        Add-Rubric -Category "SettingsForm LoadDirectorsToGrid()" -Points 4 -Status "[PASS]" -Comment "Method loads directors to DataGridView"
    } else {
        Add-Rubric -Category "SettingsForm LoadDirectorsToGrid()" -Points 4 -Status "[FAIL]" -Comment "Method not properly implemented"
    }
} else {
    Add-Rubric -Category "SettingsForm Implementation" -Points 4 -Status "[FAIL]" -Comment "SettingsForm file not found"
}

# ==================== COMPILATION CHECK ====================
Write-Host "Step 6: Checking Project Compilation..." -ForegroundColor Magenta

$projPath = Join-Path $ProjectPath "OOP.FinalTerm.Exam\OOP.FinalTerm.Exam.csproj"
if (Check-FileExists -FilePath $projPath) {
    # Try to detect obvious compilation issues
    $directorModel = Get-FileContent -FilePath (Join-Path $ProjectPath "OOP.FinalTerm.Exam\Model\DirectorModel.cs")
    $directorRepo = Get-FileContent -FilePath (Join-Path $ProjectPath "OOP.FinalTerm.Exam\Repository\DirectorRepository.cs")
    
    # Check for empty class definitions
    $isEmptyModel = $directorModel -match "class\s+DirectorModel\s*\{\s*\}"
    $isTodoRepo = $directorRepo -match "// TODO|//TODO"
    
    if ($directorModel -and $directorRepo -and -not $isEmptyModel -and -not $isTodoRepo) {
        Add-Rubric -Category "Project Compilation" -Points 2 -Status "[PASS]" -Comment "No obvious compilation errors detected"
    } elseif ($isEmptyModel -or $isTodoRepo) {
        Add-Rubric -Category "Project Compilation" -Points 2 -Status "[FAIL]" -Comment "Incomplete implementations detected (TODO comments found)"
    } else {
        Add-Rubric -Category "Project Compilation" -Points 2 -Status "[PARTIAL]" -Comment "Some incomplete implementations detected"
    }
} else {
    Add-Rubric -Category "Project Compilation" -Points 2 -Status "[FAIL]" -Comment "Could not verify project compilation - missing csproj file"
}

# ==================== GENERATE REPORT ====================
Write-Host "`n`n===== EVALUATION REPORT =====" -ForegroundColor Cyan
Write-Host ""

# Display rubric
if ($Rubric.Count -gt 0) {
    $Rubric | Format-Table -AutoSize
} else {
    Write-Host "No evaluation items recorded. Check if files exist." -ForegroundColor Red
}

Write-Host ""
Write-Host "Total Score: $Score / $MaxScore points" -ForegroundColor Green

# Calculate percentage
$percentage = [math]::Round(($Score / $MaxScore) * 100, 2)
Write-Host "Percentage: $percentage%" -ForegroundColor Green

Write-Host ""

# Grade based on percentage
if ($percentage -ge 90) {
    $grade = "A"
    $color = "Green"
} elseif ($percentage -ge 80) {
    $grade = "B"
    $color = "Cyan"
} elseif ($percentage -ge 70) {
    $grade = "C"
    $color = "Yellow"
} elseif ($percentage -ge 60) {
    $grade = "D"
    $color = "Red"
} else {
    $grade = "F"
    $color = "Red"
}

Write-Host "Grade: $grade" -ForegroundColor $color
Write-Host ""

# Summary
$passCount = ($Rubric | Where-Object { $_.Status -eq "[PASS]" }).Count
$partialCount = ($Rubric | Where-Object { $_.Status -eq "[PARTIAL]" }).Count
$failCount = ($Rubric | Where-Object { $_.Status -eq "[FAIL]" }).Count

Write-Host "Summary:" -ForegroundColor Yellow
Write-Host "  [PASS] Passed: $passCount" -ForegroundColor Green
Write-Host "  [PARTIAL] Partial: $partialCount" -ForegroundColor Yellow
Write-Host "  [FAIL] Failed: $failCount" -ForegroundColor Red

Write-Host ""
Write-Host "===== END OF REPORT =====" -ForegroundColor Cyan
Write-Host ""

# Return score for scripting purposes
return $Score
