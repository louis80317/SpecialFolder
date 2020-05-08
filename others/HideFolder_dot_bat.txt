cls
@ECHO OFF

title Folder NameOfFolder

if EXIST "DO NOT EH START.{21EC2020-3AEA-1069-A2DD-08002B30309D}" goto UNLOCK
if EXIST NameOfFolder goto CONFIRM
if NOT EXIST NameOfFolder goto MDFOLDER


:CONFIRM
echo Are you sure u want to Lock the folder(Y/N)
set/p "cho=>"
if %cho%==Y goto LOCK
if %cho%==y goto LOCK
if %cho%==n goto END
if %cho%==N goto END
echo Invalid choice.
PAUSE
goto CONFIRM


:LOCK
ren NameOfFolder "DO NOT EH START.{21EC2020-3AEA-1069-A2DD-08002B30309D}"
attrib +h +s /s /d "DO NOT EH START.{21EC2020-3AEA-1069-A2DD-08002B30309D}\*"
attrib +h +s "DO NOT EH START.{21EC2020-3AEA-1069-A2DD-08002B30309D}"
echo Folder Locked!
goto End


:UNLOCK
echo Password?
set/p "pass=>"
if NOT %pass%==589632147 goto FAIL
attrib -h -s "DO NOT EH START.{21EC2020-3AEA-1069-A2DD-08002B30309D}"
attrib -h -s /s /d "DO NOT EH START.{21EC2020-3AEA-1069-A2DD-08002B30309D}\*"
ren "DO NOT EH START.{21EC2020-3AEA-1069-A2DD-08002B30309D}" NameOfFolder
echo Folder Unlocked!
goto End


:FAIL
echo Get OUT of HERE
PAUSE
goto End


:MDFOLDER
md NameOfFolder
echo NameOfFolder folder created successfully
PAUSE
goto End


:End
PAUSE