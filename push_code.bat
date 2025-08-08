@echo off
REM Go to project folder (replace 📁 with your path or use %~dp0)
cd /d "C:\Users\user\Desktop\4Loop-Isave-repo"

git add .

git commit -m "Auto commit on %date% %time%"

git push origin main

pause
