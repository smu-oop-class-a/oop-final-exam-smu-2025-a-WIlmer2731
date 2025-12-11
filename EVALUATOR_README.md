# Exam Evaluator - Usage Guide

## Overview
The `ExamEvaluator.ps1` script automatically evaluates student exam implementations against the README requirements. It checks all 5 steps and provides a detailed scoring rubric.

## How to Run

### Method 1: Default (Current Project)
```powershell
.\ExamEvaluator.ps1
```

### Method 2: Specify Custom Project Path
```powershell
.\ExamEvaluator.ps1 -ProjectPath "C:\Path\To\OOP.FinalTerm.Exam"
```

### Method 3: Run from Different Directory
```powershell
cd d:\P\OOP.FinalTerm.Exam
powershell -ExecutionPolicy Bypass -File ExamEvaluator.ps1
```

## What It Evaluates

### Step 1: PersonModel (7 points)
- ✓ Class exists
- ✓ Has required properties (Id, FirstName, LastName)
- ✓ SQLite attributes ([PrimaryKey], [AutoIncrement]) applied

### Step 2: DirectorModel (6 points)
- ✓ Inherits from PersonModel
- ✓ Has Genres property
- ✓ Has TotalMoviesCreated property

### Step 3: DirectorRepository (12 points)
- ✓ Constructor initializes database connection
- ✓ AddDirector() method uses Insert()
- ✓ GetAllDirectors() uses Table().ToList()
- ✓ GetDirectorById() uses Find()

### Step 4: DirectorForm (9 points)
- ✓ All required form controls present (txtFirstName, txtLastName, txtGenres, numTotalMovies, btnSave, btnCancel)
- ✓ GetDirector() method maps form controls to properties
- ✓ BtnSave_Click() includes validation

### Step 5: SettingsForm (4 points)
- ✓ LoadDirectorsToGrid() loads directors from repository to DataGridView

### Project Compilation (2 points)
- ✓ No obvious compilation errors detected

## Scoring Breakdown

- **Total Points: 50**
- **Scoring System:**
  - ✓ PASS = Full points awarded
  - ⚠ PARTIAL = Half points awarded (implementation exists but may be incomplete)
  - ✗ FAIL = No points awarded

## Output Explanation

### Grade Scale
- **A** (90-100%)
- **B** (80-89%)
- **C** (70-79%)
- **D** (60-69%)
- **F** (Below 60%)

### Example Output
```
===== EVALUATION REPORT =====

Category                                        Points Status  Comment
--------                                        ------ ------  -------
PersonModel Class                                   5 ✓ PASS  Class exists with all required properties
PersonModel SQLite Attributes                      2 ✓ PASS  SQLite attributes properly applied
DirectorModel Inheritance                          3 ✓ PASS  Properly inherits from PersonModel
...

Total Score: 42 / 50 points
Percentage: 84%
Grade: B

Summary:
  ✓ Passed: 14
  ⚠ Partial: 2
  ✗ Failed: 0
```

## Notes

- The evaluation is **not strict** - it checks for core functionality and patterns
- PARTIAL status means the feature exists but may need minor fixes
- The script uses pattern matching to detect implementations, so minor variations in code style are acceptable
- If a file is missing, the script will skip those checks but won't fail the entire evaluation
- The script looks for logical implementations rather than exact code matches

## Troubleshooting

### Script Won't Run
If you get an execution policy error:
```powershell
Set-ExecutionPolicy -ExecutionPolicy Bypass -Scope Process
```

### Wrong Project Path
Make sure the path matches your actual project location:
```powershell
Get-ChildItem "d:\P\OOP.FinalTerm.Exam" -Recurse -Include "*.csproj"
```

### Always Shows Partial
This typically means implementations exist but may have syntax issues. Check:
1. Class/method names match exactly (case-sensitive)
2. Required code patterns are present
3. Files are saved with correct extensions (.cs)

## For Instructors

This script is designed to:
- Save time on initial evaluation
- Provide consistent, objective feedback
- Highlight areas needing improvement
- Not be 100% strict (allows reasonable variations)
- Give students confidence that their work is on track

You can still manually review implementations for quality and best practices beyond what the script checks.
