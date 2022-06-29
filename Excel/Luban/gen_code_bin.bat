set WORKSPACE=..\..

set GEN_CLIENT=%WORKSPACE%\Tools\Luban\Tools\Luban.ClientServer\Luban.ClientServer.exe
set CONF_ROOT=%WORKSPACE%\Excel\Luban


%GEN_CLIENT% --template_search_path HotfixTemplates -j cfg --^
 -d %CONF_ROOT%\Hotfix\Defines\__root__.xml ^
 --input_data_dir %CONF_ROOT%\Hotfix\Datas ^
 --output_code_dir %WORKSPACE%\Assets\Scripts\Hotfix\Model\Generate\Luban ^
 --output_data_dir %WORKSPACE%\Assets\Res\Luban\Hotfix ^
 --gen_types code_cs_unity_bin,data_bin ^
 -s all 


%GEN_CLIENT% --template_search_path MonoTemplates -j cfg --^
 -d %CONF_ROOT%\Mono\Defines\__root__.xml ^
 --input_data_dir %CONF_ROOT%\Mono\Datas ^
 --output_code_dir %WORKSPACE%\Assets\Scripts\Mono\Luban\Generate ^
 --output_data_dir %WORKSPACE%\Assets\Res\Luban\Mono ^
 --gen_types code_cs_unity_bin,data_bin ^
 -s all 

pause