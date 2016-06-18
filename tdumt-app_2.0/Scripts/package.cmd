@ECHO OFF
ECHO Will package trunk only !
ECHO Release build OK in VS2012 ?
PAUSE
ECHO.
ECHO * Preparing out folder...
RMDIR ..\packaging /S /Q
MKDIR "..\packaging\TDU Modding Tools 2"
ECHO.
ECHO * App: Mini BNK Manager...
MKDIR "..\packaging\TDU Modding Tools 2\Mini BNK Manager"
MKDIR "..\packaging\TDU Modding Tools 2\Mini BNK Manager\Conf"
MKDIR "..\packaging\TDU Modding Tools 2\Mini BNK Manager\Logs"
COPY "..\TDUMT_2_MiniBnk\bin\Release\*.dll" "..\packaging\TDU Modding Tools 2\Mini BNK Manager\"
COPY "..\TDUMT_2_MiniBnk\bin\Release\MiniBnkManager.exe*" "..\packaging\TDU Modding Tools 2\Mini BNK Manager\"
COPY "..\TDUMT_2_MiniBnk\bin\Release\Conf\*.xml" "..\packaging\TDU Modding Tools 2\Mini BNK Manager\Conf\"
ECHO.
ECHO * App: Mini XMB...
MKDIR "..\packaging\TDU Modding Tools 2\Mini XMB"
MKDIR "..\packaging\TDU Modding Tools 2\Mini XMB\Conf"
MKDIR "..\packaging\TDU Modding Tools 2\Mini XMB\Logs"
COPY "..\TDUMT_2_MiniXmb\bin\Release\*.dll" "..\packaging\TDU Modding Tools 2\Mini XMB\"
COPY "..\TDUMT_2_MiniXmb\bin\Release\MiniXmb.exe*" "..\packaging\TDU Modding Tools 2\Mini XMB\"
COPY "..\TDUMT_2_MiniXmb\bin\Release\Conf\*.xml" "..\packaging\TDU Modding Tools 2\Mini XMB\Conf\"
ECHO.
ECHO * Readme...
COPY "..\TDUMT_2_Main\res\readme\README FIRST - TDUMT2.txt" "..\packaging\TDU Modding Tools 2\" 
REM TODO: zip
ECHO.
ECHO All done !
PAUSE