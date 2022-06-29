#!/bin/zsh
WORKSPACE=../..

GEN_CLIENT=${WORKSPACE}/Tools/Luban/Tools/Luban.ClientServer/Luban.ClientServer.dll
CONF_ROOT=${WORKSPACE}/Configs/Luban


dotnet ${GEN_CLIENT} --template_search_path HotfixTemplates -j cfg --\
 -d ${CONF_ROOT}/Hotfix/Defines/__root__.xml \
 --input_data_dir ${CONF_ROOT}/Hotfix/Datas \
 --output_code_dir ${WORKSPACE}/Assets/Scripts/Hotfix/Model/Generate/Luban \
 --output_data_dir ${WORKSPACE}/Assets/Res/Luban/Hotfix \
 --gen_types code_cs_bin,data_bin \
 -s all 


 dotnet ${GEN_CLIENT} --template_search_path GameTemplates -j cfg --\
 -d ${CONF_ROOT}/Game/Defines/__root__.xml \
 --input_data_dir ${CONF_ROOT}/Game/Datas \
 --output_code_dir ${WORKSPACE}/Assets/Scripts/Game/Generate/Luban \
 --output_data_dir ${WORKSPACE}/Assets/Res/Luban/Game \
 --gen_types code_cs_bin,data_bin \
 -s all 
