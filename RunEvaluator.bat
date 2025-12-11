@echo off
REM Quick Launch Script for Exam Evaluator
REM This makes it easier to run the evaluator without using PowerShell directly

echo.
echo ===== OOP Final Term Exam Evaluator =====
echo.
echo Running evaluation...
echo.

powershell -ExecutionPolicy Bypass -File "%~dp0ExamEvaluator.ps1"

echo.
pause
