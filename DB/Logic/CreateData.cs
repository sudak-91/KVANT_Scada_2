using KVANT_Scada_2.DB.Entity;
using KVANT_Scada_2.Objects;
using KVANT_Scada_2.OPCUAWorker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KVANT_Scada_2.DB.Logic
{
    class CreateData
    {

        TimerCallback tm;
        Timer timer;
        object SQLLocker;
        Objects.OPCObjects objects;
        

        public CreateData() 
        {
           
        }
        public void CreateTables()
        {
            SQLLocker = new object();
            //objects = Objects.OPCObjects.createObjects();
            OPCObjects.SQLLocker = SQLLocker;
            lock (OPCObjects.SQLLocker)
            {
                using (var context = new MyDBContext())
                {
                    context.Database.EnsureCreated();
                    createCamPrepTable(context);
                    createCrioPumpStartTable(context);
                    createCrioPumpTable(context);
                    createFVPTable(context);
                    createIonTable(context);
                    createOpenCamTable(context);
                    createStopCrioTable(context);
                    createStopFVPTable(context);
                    CreateValveTable(context);
                    CreateAnalogTable(context);
                    CreateDigitalTable(context);
                    CreateIntTable(context);
                    context.SaveChanges();
                    context.Dispose();
                } 

                
            }
            tm = new TimerCallback(TimerUpdateSQL);
            timer = new Timer(tm, SQLLocker, 0, 1000);

        }

        private static void createStopFVPTable(MyDBContext context)
        {
            
                
                var stopFVPtable = context.StopFVP.Where(x => x.Name == "StopFVP");
                if (stopFVPtable.Count() == 0)
                {
                    var sft = new StopFVPTable
                    {
                        Id = 1,
                        Name = "StopFVP"
                    };
                    context.StopFVP.Add(sft);
                    context.SaveChanges();

            }
                else
                {
                    Console.WriteLine("StopFVP Table is created");
                }
                
            

        }
        private static void createStopCrioTable(MyDBContext context)
        {
            
                
                var stopCriotable = context.StopCrio.Where(x => x.Name == "StopCrio");
                if (stopCriotable.Count() == 0)
                {
                    var sct = new StopCrioTable
                    {
                        Id =1,
                        Name = "StopCrio"
                    };
                    context.StopCrio.Add(sct);
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("StopCrio Table is created");
                }
               
            

        }
        private static void createOpenCamTable(MyDBContext context)
        {
            
                ;
                var openCamTables = context.OpenCam.Where(x => x.Name == "OpenCam");
                if (openCamTables.Count() == 0)
                {
                    var oct = new OpenCamTable
                    {
                        Id=1,
                        Name = "OpenCam"
                    };
                    context.OpenCam.Add(oct);
                    context.SaveChanges();
            }
                else
                {
                    Console.WriteLine("Open Camera Table is created");
                }
                
            

        }
        private static void createCrioPumpStartTable(MyDBContext context)
        {
           
                
                var CrioPumpStart = context.CrioPumpStart.Where(x => x.Name == "CrioPumpStart");
                if (CrioPumpStart.Count() == 0)
                {
                    var cps = new CrioPumpStartTable
                    {
                        Id=1,
                        Name = "CrioPumpStart"
                    };
                    context.CrioPumpStart.Add(cps);
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("CrioPumpStart Table is created");
                }
    

        }
        private static void createCamPrepTable(MyDBContext context)
        {
           
                
                var campreptable = context.CamPrepTable.Where(x => x.Name == "CameraPrepare");
                if (campreptable.Count() == 0)
                {
                    var cp = new CamPreapreTable
                    {
                        Id=1,
                        Name = "CameraPrepare"
                    };
                    context.CamPrepTable.Add(cp);
                    context.SaveChanges();


            }
                else
                {
                    Console.WriteLine("CameraPrepare Table is created");
                }
           
            

        }
        private static void createIonTable(MyDBContext context)
        {
            
                
                var ion = context.Ion.Where(x => x.Name == "Ion");
                if (ion.Count() == 0)
                {
                    var ionent = new Ion
                    {
                        Id =1,
                        Name = "Ion"
                    };
                    context.Ion.Add(ionent);
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("CrioPump Table is created");
                }
       

        }
        private static void createCrioPumpTable(MyDBContext context)
        {
            
               
                var crioPump = context.CrioPump.Where(x => x.Name == "CrioPump");
                if(crioPump.Count()==0)
                {
                    var crio = new CrioPump
                    {
                        Id=1,
                        Name = "CrioPump"
                    };
                    context.CrioPump.Add(crio);
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("CrioPump Table is created");
                }
         
        }
        private static void createFVPTable(MyDBContext context)
        {
            
                
                var fvp = context.FVP.Where(x => x.Name == "FVP");
                if (fvp.Count() == 0)
                {
                    var enfvp = new FVP
                    {
                        Id =1,
                        Name = "FVP"
                        
                    };
                    context.FVP.Add(enfvp);
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("FVP Table is created");
                }
                
           

        }
        private static void CreateValveTable(MyDBContext context)
        {
            
                
                var BAV_3 = context.Valve.Where(x => x.Name == "BAV_3");
                if (BAV_3.Count() == 0)
                {
                    var valveBAV_3 = new Valves
                    {
                        Id =1,
                        Name = "BAV_3",
                        PathInput = OPCUAWorkerPaths.BAV_3_Input_path,
                        PathStatus = OPCUAWorkerPaths.BAV_3_Status_path
                        

                    };
                    context.Valve.Add(valveBAV_3);
                    
                }
                else
                {
                    Console.WriteLine("Данная запись уже есть");
                }

                var SHV = context.Valve.Where(x => x.Name == "SHV");
                if(SHV.Count() == 0)
                {
                    var valve = new Valves
                    {
                        Id = 2,
                        Name = "SHV",
                        PathInput = OPCUAWorkerPaths.SHV_Input_path,
                        PathStatus = OPCUAWorkerPaths.SHV_Status_path
                    };
                    context.Valve.Add(valve);
                }
                else
                {
                    Console.WriteLine("Запись SHV уже создана");
                }

                var FVV_S = context.Valve.Where(x => x.Name == "FVV_S");
                if(FVV_S.Count() == 0)
                {
                    var valve = new Valves
                    {
                        Id = 3,
                        Name = "FVV_S",
                        PathInput = OPCUAWorkerPaths.FVV_S_Input_path,
                        PathStatus = OPCUAWorkerPaths.FVV_S_Status_path
                    };
                    context.Valve.Add(valve);
                }
                else
                {
                    Console.WriteLine("Запись FVV_S уже создана");
                }

                var FVV_B = context.Valve.Where(x => x.Name == "FVV_B");
                if(FVV_B.Count() == 0)
                {
                    var valve = new Valves
                    {
                        Id = 4,
                        Name = "FVV_B",
                        PathInput = OPCUAWorkerPaths.FVV_B_Input_path,
                        PathStatus = OPCUAWorkerPaths.FVV_B_Status_path
                    };
                    context.Valve.Add(valve);
                }
                else
                {
                    Console.WriteLine("Запись FVV_B уже создана");
                }
                var CPV = context.Valve.Where(x => x.Name == "CPV");
                if(CPV.Count() == 0)
                {
                    var valve = new Valves
                    {
                        Id = 5,
                        Name = "CPV",
                        PathInput = OPCUAWorkerPaths.CPV_Input_path,
                        PathStatus = OPCUAWorkerPaths.CPV_Status_path
                    };
                    context.Valve.Add(valve);
                }
                else
                {
                    Console.WriteLine("Запись CPV уже создана");
                }
                context.SaveChanges();


        }
        private static void CreateAnalogTable(MyDBContext context)
        {
            var count = context.AnalogValue.Count();
            if (count == 0)
            {
                var rsft01_ft = new AnalogaValueTable
                {
                    Name = "SFT01_FT",
                    Path = OPCUAWorkerPaths.SFT01_FT_path
                };
                var rsft02_ft = new AnalogaValueTable
                {
                    Name = "SFT02_FT",
                    Path = OPCUAWorkerPaths.SFT02_FT_path
                };
                var rsft03_ft = new AnalogaValueTable
                {
                    Name = "SFT03_FT",
                    Path = OPCUAWorkerPaths.SFT03_FT_path
                };
                var rsft04_ft = new AnalogaValueTable
                {
                    Name = "SFT04_FT",
                    Path = OPCUAWorkerPaths.SFT04_FT_path
                };
                var rsft05_ft = new AnalogaValueTable
                {
                    Name = "SFT05_FT",
                    Path = OPCUAWorkerPaths.SFT05_FT_path
                };
                var rsft06_ft = new AnalogaValueTable
                {
                    Name = "SFT06_FT",
                    Path = OPCUAWorkerPaths.SFT06_FT_path
                };
                var rsft07_ft = new AnalogaValueTable
                {
                    Name = "SFT07_FT",
                    Path = OPCUAWorkerPaths.SFT07_FT_path
                };
                var rsft08_ft = new AnalogaValueTable
                {
                    Name = "SFT08_FT",
                    Path = OPCUAWorkerPaths.SFT08_FT_path
                };
                var rsft09_ft = new AnalogaValueTable
                {
                    Name = "SFT09_FT",
                    Path = OPCUAWorkerPaths.SFT09_FT_path
                };
                var rsft10_ft = new AnalogaValueTable
                {
                    Name = "SFT10_FT",
                    Path = OPCUAWorkerPaths.SFT10_FT_path
                };
                var rft_tt_1 = new AnalogaValueTable
                {
                    Name = "FT_TT_1",
                    Path = OPCUAWorkerPaths.FT_TT_1_path
                };
                var rft_tt_2 = new AnalogaValueTable
                {
                    Name = "FT_TT_2",
                    Path = OPCUAWorkerPaths.FT_TT_2_path
                };
                var rft_tt_3 = new AnalogaValueTable
                {
                    Name = "FT_TT_3",
                    Path = OPCUAWorkerPaths.FT_TT_3_path
                };
                var rrrg_9a1_fb = new AnalogaValueTable
                {
                    Name = "RRG_9A1_feedback",
                    Path = OPCUAWorkerPaths.RRG_9A1_feedback_path
                };
                var rrrg_9a2_fb = new AnalogaValueTable
                {
                    Name = "RRG_9A2_feedback",
                    Path = OPCUAWorkerPaths.RRG_9A2_feedback_path
                };
                var rrrg_9a3_fb = new AnalogaValueTable
                {
                    Name = "RRG_9A3_feedback",
                    Path = OPCUAWorkerPaths.RRG_9A3_feedback_path
                };
                var rrrg_9a4_fb = new AnalogaValueTable
                {
                    Name = "RRG_9A4_feedback",
                    Path = OPCUAWorkerPaths.RRG_9A4_feedback_path
                };
                var rte_1 = new AnalogaValueTable
                {
                    Name = "TE_1",
                    Path = OPCUAWorkerPaths.TE_1_path
                };
                var rpneumaticpres = new AnalogaValueTable
                {
                    Name = "Preumatic_Pressure",
                    Path = OPCUAWorkerPaths.PneumaticPressure_path
                };
                var rcriopres = new AnalogaValueTable
                {
                    Name = "Crio_Pressure",
                    Path = OPCUAWorkerPaths.CrioPressure_path
                };
                var rcampres = new AnalogaValueTable
                {
                    Name = "Camera_Pressure",
                    Path = OPCUAWorkerPaths.CameraPressure_path
                };
                var rmainres = new AnalogaValueTable
                {
                    Name = "Main_Pressure",
                    Path = OPCUAWorkerPaths.MainPressure_path
                };
                var rcriotemp = new AnalogaValueTable
                {
                    Name = "Crio_Temperature",
                    Path = OPCUAWorkerPaths.CrioTemperature_path
                };
                var rpreheat_temp_sp = new AnalogaValueTable
                {
                    Name = "PreHeat_Temp_SP",
                    Path = OPCUAWorkerPaths.PreHeat_Temp_SP_path
                };
                var rheatassist_temp_sp = new AnalogaValueTable
                {
                    Name = "HeatAssist_Temp_SP",
                    Path = OPCUAWorkerPaths.HeatAssist_Temp_SP_path
                };
                var rpreheat_timer_sp = new AnalogaValueTable
                {
                    Name = "PreHeat_Timer_SP",
                    Path = OPCUAWorkerPaths.PreHeat_Timer_path
                };
                var rheatassist_timer_sp = new AnalogaValueTable
                {
                    Name = "HeatAssist_Timer_SP",
                    Path = OPCUAWorkerPaths.HeatAssist_Timer_path
                };
                var rmanualsettemp = new AnalogaValueTable
                {
                    Name = "ManualSetTemp",
                    Path = OPCUAWorkerPaths.ManualSetTemp_path
                };
                var rblmspeed = new AnalogaValueTable
                {
                    Name = "BLM_Speed",
                    Path = OPCUAWorkerPaths.BLM_Speed_path
                };
                var rblmspeedsp = new AnalogaValueTable
                {
                    Name = "BLM_Speed_SP",
                    Path = OPCUAWorkerPaths.BLM_Speed_SP_path
                };
                var rrrg1_k = new AnalogaValueTable
                {
                    Name = "K_RRG1",
                    Path = OPCUAWorkerPaths.K_RRG1_path
                };
                var rrrg2_k = new AnalogaValueTable
                {
                    Name = "K_RRG2",
                    Path = OPCUAWorkerPaths.K_RRG2_path
                };
                var rrrg3_k = new AnalogaValueTable
                {
                    Name = "K_RRG3",
                    Path = OPCUAWorkerPaths.K_RRG3_path
                };
                var rrrg4_k = new AnalogaValueTable
                {
                    Name = "K_RRG4",
                    Path = OPCUAWorkerPaths.K_RRG4_path
                };
                var rrrg_pres_sp = new AnalogaValueTable
                {
                    Name = "RRG_Pressure_SP",
                    Path = OPCUAWorkerPaths.RRG_Pressure_SP
                };
                context.AnalogValue.Add(rft_tt_1);
                context.AnalogValue.Add(rft_tt_2);
                context.AnalogValue.Add(rft_tt_3);
                context.AnalogValue.Add(rheatassist_temp_sp);
                context.AnalogValue.Add(rheatassist_timer_sp);
                context.AnalogValue.Add(rmainres);
                context.AnalogValue.Add(rmanualsettemp);
                context.AnalogValue.Add(rpneumaticpres);
                context.AnalogValue.Add(rpreheat_temp_sp);
                context.AnalogValue.Add(rpreheat_timer_sp);
                context.AnalogValue.Add(rrrg_9a1_fb);
                context.AnalogValue.Add(rrrg_9a2_fb);
                context.AnalogValue.Add(rrrg_9a3_fb);
                context.AnalogValue.Add(rrrg_9a4_fb);
                context.AnalogValue.Add(rsft01_ft);
                context.AnalogValue.Add(rsft02_ft);
                context.AnalogValue.Add(rsft03_ft);
                context.AnalogValue.Add(rsft04_ft);
                context.AnalogValue.Add(rsft05_ft);
                context.AnalogValue.Add(rsft06_ft);
                context.AnalogValue.Add(rsft07_ft);
                context.AnalogValue.Add(rsft08_ft);
                context.AnalogValue.Add(rsft09_ft);
                context.AnalogValue.Add(rsft10_ft);
                context.AnalogValue.Add(rte_1);
                context.AnalogValue.Add(rblmspeed);
                context.AnalogValue.Add(rblmspeedsp);
                context.AnalogValue.Add(rcampres);
                context.AnalogValue.Add(rcriopres);
                context.AnalogValue.Add(rcriotemp);
                context.AnalogValue.Add(rrrg1_k);
                context.AnalogValue.Add(rrrg2_k);
                context.AnalogValue.Add(rrrg3_k);
                context.AnalogValue.Add(rrrg4_k);
                context.AnalogValue.Add(rrrg_pres_sp);
                context.SaveChanges();

            }
            
        }
        private static void CreateDigitalTable(MyDBContext context)
        {
            var count = context.DigitalValue.Count();
            if(count == 0)
            {
                var bpreheatdone = new DigitalValueTable
                {
                    Name = "PreHeat_Done",
                    Path = OPCUAWorkerPaths.PreHeat_Done_path
                };
                var bheatassistdone = new DigitalValueTable
                {
                    Name = "HeatAssist_Done",
                    Path = OPCUAWorkerPaths.HeatAssist_Done_path                    
                };
                var bpreheatstart  = new DigitalValueTable
                {
                    Name = "PreHeat_Start",
                    Path = OPCUAWorkerPaths.PreHeat_Start_path
                };
                var bheatassistflag = new DigitalValueTable
                {
                    Name = "HeatAssist_Flag",
                    Path = OPCUAWorkerPaths.HeatAssist_Flag_path
                };
                var bheatdone = new DigitalValueTable
                {
                    Name = "Heat_Done",
                    Path = OPCUAWorkerPaths.Heat_Done_path
                };
                var bheatassisttempdone = new DigitalValueTable
                {
                    Name = "HeatAssist_TempDone",
                    Path = OPCUAWorkerPaths.HeatAssist_TempDone_path
                };
                var bheatassiston = new DigitalValueTable
                {
                    Name = "Heat_Assist_On",
                    Path = OPCUAWorkerPaths.Heat_Assist_ON_path
                };
                var bblmsstart = new DigitalValueTable
                {
                    Name = "BLM_Start",
                    Path = OPCUAWorkerPaths.BLM_Start_path
                };
                var bblmstop = new DigitalValueTable
                {
                    Name = "BLM_Stop",
                    Path = OPCUAWorkerPaths.BLM_Stop_path
                };
                var bblmremotecontroldone = new DigitalValueTable
                {
                    Name = "BLM_Remote_Control_Done",
                    Path = OPCUAWorkerPaths.BLM_Remote_Control_Done_path
                };
                var bblmrun = new DigitalValueTable
                {
                    Name = "BLM_Run",
                    Path = OPCUAWorkerPaths.BLM_Run_path
                };
                var balarmopendoor = new DigitalValueTable
                {
                    Name = "Alarm_Open_door",
                    Path = OPCUAWorkerPaths.Alarm_Open_door_path
                };
                var balarmwatercrio = new DigitalValueTable
                {
                    Name = "Alarm_Water_CRIO",
                    Path = OPCUAWorkerPaths.Alarm_Water_CRIO_path
                };
                var balarmhightpnepress = new DigitalValueTable
                {
                    Name = "Alarm_Hight_Pne_Presse",
                    Path = OPCUAWorkerPaths.Alarm_Hight_Pne_Presse_path
                };
                var balarmlowonepresse = new DigitalValueTable
                {
                    Name = "Alarm_Low_One_Presse",
                    Path = OPCUAWorkerPaths.Alarm_Low_One_Presse_path
                };
                var balarmcriopowerfailure = new DigitalValueTable
                {
                    Name = "Alarm_Crio_power_failure",
                    Path = OPCUAWorkerPaths.Alarm_Crio_power_failure_path
                };
                var balarmquartzpowerfailure = new DigitalValueTable
                {
                    Name = "Alarm_Qartz_power_filure",
                    Path = OPCUAWorkerPaths.Alarm_Qartz_power_filure_path
                };
                var balarmelipowerfailure = new DigitalValueTable
                {
                    Name = "Alarm_ELI_power_failure",
                    Path = OPCUAWorkerPaths.Alarm_ELI_power_failure_path
                };
                var balarmfloatheaterpowerfailure = new DigitalValueTable
                {
                    Name = "Alarm_FloatHeatr_power_failure",
                    Path = OPCUAWorkerPaths.Alarm_FloatHeater_power_failure_path
                };
                var balarmfvppowerfailure = new DigitalValueTable
                {
                    Name = "Alarm_FVP_power_failure",
                    Path = OPCUAWorkerPaths.Alarm_FVP_power_failure_path

                };
                var balarmionpowerfailure = new DigitalValueTable
                {
                    Name = "Alarm_Ion_Power_Failure",
                    Path = OPCUAWorkerPaths.Alarm_Ion_power_failure_path
                };
                var balarmindexerpowerfailure = new DigitalValueTable
                {
                    Name = "Alarm_Indexer_power_failure",
                    Path = OPCUAWorkerPaths.Alarm_Indexer_power_failure_path
                };
                var balarmssppowerfailure = new DigitalValueTable
                {
                    Name = "Alarm_SSP_power_failure",
                    Path = OPCUAWorkerPaths.Alarm_SSP_power_failure_path
                };
                var balarmtv1powerfailure = new DigitalValueTable
                {
                    Name = "Alarm_TV1_power_failure",
                    Path = OPCUAWorkerPaths.Alarm_TV1_power_failure_path
                };
                var balarmwatersecond = new DigitalValueTable
                {
                    Name = "Alarm_Water_SECOND",
                    Path = OPCUAWorkerPaths.Alarm_Water_SECOND_path
                };
                var balarmhightcriotemp= new DigitalValueTable
                {
                    Name = "Alarm_Hight_Crio_Temp",
                    Path = OPCUAWorkerPaths.Alarm_Hight_Crio_Temp_path
                };
                var bcriostartsignal = new DigitalValueTable
                {
                    Name = "Crio_start_signal",
                    Path = OPCUAWorkerPaths.Crio_start_signal_path
                };
                var balarmmanualstop= new DigitalValueTable
                {
                    Name = "Alarm_manual_Stop",
                    Path = OPCUAWorkerPaths.Alarm_manual_Stop_path
                };
                var bmanualstop = new DigitalValueTable
                {
                    Name = "Manual_Stop",
                    Path = OPCUAWorkerPaths.StopProcessSignal_path
                };
                var bstartprocesssignal = new DigitalValueTable
                {
                    Name = "Start_Process",
                    Path = OPCUAWorkerPaths.StartProcessSignal_path
                };
                context.DigitalValue.Add(balarmcriopowerfailure);
                context.DigitalValue.Add(balarmelipowerfailure);
                context.DigitalValue.Add(balarmfloatheaterpowerfailure);
                context.DigitalValue.Add(balarmfvppowerfailure);
                context.DigitalValue.Add(balarmhightcriotemp);
                context.DigitalValue.Add(balarmhightpnepress);
                context.DigitalValue.Add(balarmindexerpowerfailure);
                context.DigitalValue.Add(balarmionpowerfailure);
                context.DigitalValue.Add(balarmlowonepresse);
                context.DigitalValue.Add(balarmmanualstop);
                context.DigitalValue.Add(balarmopendoor);
                context.DigitalValue.Add(balarmquartzpowerfailure);
                context.DigitalValue.Add(balarmssppowerfailure);
                context.DigitalValue.Add(balarmtv1powerfailure);
                context.DigitalValue.Add(balarmwatercrio);
                context.DigitalValue.Add(balarmwatersecond);
                context.DigitalValue.Add(bblmremotecontroldone);
                context.DigitalValue.Add(bblmrun);
                context.DigitalValue.Add(bblmsstart);
                context.DigitalValue.Add(bblmstop);
                context.DigitalValue.Add(bcriostartsignal);
                context.DigitalValue.Add(bheatassistdone);
                context.DigitalValue.Add(bheatassistflag);
                context.DigitalValue.Add(bheatassiston);
                context.DigitalValue.Add(bheatassisttempdone);
                context.DigitalValue.Add(bheatdone);
                context.DigitalValue.Add(bpreheatdone);
                context.DigitalValue.Add(bpreheatstart);
                context.DigitalValue.Add(bmanualstop);
                context.DigitalValue.Add(bstartprocesssignal);
                context.SaveChanges();

            }
        }
        private static void CreateIntTable (MyDBContext context)
        {
            var count = context.IntValue.Count();
            if(count == 0)
            {
                var ipreheatstage = new IntValueTable
                {
                    Name = "PreHeat_Stage",
                    Path = OPCUAWorkerPaths.PreHeat_Stage_path
                };
                var iheatassiststage  = new IntValueTable
                {
                    Name = "HeatAssist_Stage",
                    Path = OPCUAWorkerPaths.HeatAssist_Stage_path
                };
                var itechcamstage = new IntValueTable
                {
                    Name = "Tech_cam_STAGE",
                    Path = OPCUAWorkerPaths.Tech_cam_STAGE_path
                };
                var ifullcyclestage = new IntValueTable
                {
                    Name = "Full_Cycle_Stage",
                    Path = OPCUAWorkerPaths.FullCycleStage_path
                };
                context.IntValue.Add(iheatassiststage);
                context.IntValue.Add(ipreheatstage);
                context.IntValue.Add(itechcamstage);
                context.IntValue.Add(ifullcyclestage);
                context.SaveChanges();
            }
        }




        public static void TimerUpdateSQL(object obj)
        {
            UpdateCamPrepTable(obj);
                    //UpdateCrioPumpStartTable();
            UpdateAnalogValue();
            UpdateDigitalValue();
            UpdateIntValue();
            UpdateCrioPumpStartTable();
            UpdateOpenCamTable();
            UpdateStopCrioTable();
            UpdateStopFVPTable();
            UpdateCrioPump();
            UpdateFVP();
            UpdateION();
            UpdateValves();






        }
        private static void UpdateCamPrepTable(object obj)
        {
            var objects = OPCObjects.createObjects();
            var opclocking = objects.getOPCLocker();
            lock (opclocking)
            {
               
                var CamPrepOPC = objects.get_camPrepare();
                var locking = obj;
                
                lock (locking)
                {
                    using (var context = new MyDBContext())
                    {
                        var camprepobject = context.CamPrepTable.Where(e => e.Id == 1);
                        foreach (var cam in camprepobject)
                        {

                            cam.Access = CamPrepOPC.Access;
                            cam.Finally_pressure = CamPrepOPC.Finally_pressure;
                            cam.Open_FVV_B_pressure = CamPrepOPC.Open_FVV_B_pressure;
                            cam.Open_SHV_pressure = CamPrepOPC.Open_SHV_pressure;
                            cam.Return_ERROR = CamPrepOPC.Return_ERROR;
                            cam.Stage_0_Cam_prepare_Complite = CamPrepOPC.Stage_0_Cam_prepare_Complite;
                            cam.Stage_0_Cam_prepare_Stage = CamPrepOPC.Stage_0_Cam_prepare_Stage;
                            context.Update(cam);
                            Console.WriteLine("Node Name = {0}", cam.Name);
                            Console.WriteLine("In DB we sent ={0}", cam.Open_FVV_B_pressure);
                            Console.WriteLine("In OPC Value ={0}", CamPrepOPC.Open_FVV_B_pressure);
                            
                            
                        }
                        context.SaveChanges();
                        context.Dispose();
                    }
                   
                        
                        Console.WriteLine("CHECK DB");
                        
  
                                     
                }
                
            }
            
        }
        private static void UpdateCrioPumpStartTable()
        {
            lock (OPCObjects.OPCLocker)
            {
                lock (OPCObjects.SQLLocker)
                {
                    using (var context = new MyDBContext())
                    {
                        var opcriopumpstart = Objects.OPCObjects.createObjects().GetCrioPumpStart();
                        var criopumpsstart = context.CrioPumpStart.Where(e => e.Id == 1);
                        foreach (var cp in criopumpsstart)
                        {
                            cp.Return_error = opcriopumpstart.Return_error;
                            cp.Stage_0_CompliteP = opcriopumpstart.Stage_0_CompliteP;
                            cp.Stage_0_Stage = opcriopumpstart.Stage_0_Stage;
                            cp.Temperature_SP = opcriopumpstart.Temperature_SP;
                            context.Update(cp);
                            

                        }
                        context.SaveChanges();
                        context.Dispose();
                    }
                }
            }
        }
        private static void UpdateOpenCamTable()
        {
            using(var context = new MyDBContext())
            {
                var opcopencamtable = Objects.OPCObjects.createObjects().GetOpenCam();
                var opencamvalues = context.OpenCam.Where(e => e.Id == 1);
                foreach(var oc in opencamvalues)
                {
                    oc.Access = opcopencamtable.Access;
                    oc.Heat_cam = opcopencamtable.Heat_cam;
                    oc.Stage_1_done = opcopencamtable.Stage_1_done;
                    oc.Stage_1_Return = opcopencamtable.Stage_1_Return;
                    oc.Stage_1_stage = opcopencamtable.Stage_1_stage;
                    context.Update(oc);
                    
                }
                context.SaveChanges();
            }
        }
        private static void UpdateStopCrioTable()
        {
            using(var context = new MyDBContext())
            {
                var opcstopcriotable = Objects.OPCObjects.createObjects().GetStopCrio();
                var stopcriovalues = context.StopCrio.Where(e => e.Id == 1);
                foreach (var sc in stopcriovalues)
                {
                    sc.Access = opcstopcriotable.Access;
                    sc.Stage_2_done = opcstopcriotable.Stage_2_done;
                    sc.Stage_2_Return = opcstopcriotable.Stage_2_Return;
                    sc.Stage_2_Stage = opcstopcriotable.Stage_2_Stage;
                    context.Update(sc);
                    
                }
                context.SaveChanges();
            }
        }
        private static void UpdateStopFVPTable()
        {
            using(var context = new MyDBContext())
            {
                var opcstopfvp = Objects.OPCObjects.createObjects().GetStopFVP();
                var stopfvpvalues = context.StopFVP.Where(e => e.Id == 1);
                foreach(var sf in stopfvpvalues)
                {
                    sf.Access = opcstopfvp.Access;
                    sf.Stage_3_Done = opcstopfvp.Stage_3_Done;
                    sf.Stage_3_Return = opcstopfvp.Stage_3_Return;
                    context.Update(sf);
                    
                }
                context.SaveChanges();
            }
        }
        private static void UpdateAnalogValue()
        {
            lock (OPCObjects.OPCLocker)
            {
                lock (OPCObjects.SQLLocker)
                {

                    using (var context = new MyDBContext())
                    {
                        foreach (var analogvalue in OPCObjects.AnalogValues)
                        {
                            var entitys = context.AnalogValue.Where(e => e.Path == analogvalue.Path);
                            foreach (var entity in entitys)
                            {
                                entity.Value = analogvalue.Value;
                                context.AnalogValue.Update(entity);
                                
                            }
                           
                        }
                        context.SaveChanges();
                        context.Dispose();

                    }
                }
            }
        }
        private static void UpdateDigitalValue()
        {
            lock (OPCObjects.OPCLocker)
            {
                lock (OPCObjects.SQLLocker)
                {

                    using (var context = new MyDBContext())
                    {
                        foreach (var discretevalue in OPCObjects.DiscreteValues)
                        {
                            var entitys = context.DigitalValue.Where(e => e.Path ==discretevalue.Path);
                            foreach (var entity in entitys)
                            {
                                entity.Value = discretevalue.Value;
                                context.DigitalValue.Update(entity);

                            }

                        }
                        context.SaveChanges();
                        context.Dispose();

                    }
                }
            }
        }
        private static void UpdateIntValue()
        {
            lock(OPCObjects.OPCLocker)
            {
                lock(OPCObjects.SQLLocker)
                {
                    using (var context = new MyDBContext())
                    {
                        foreach(var intvalue in OPCObjects.IntValues)
                        {
                            var entitys = context.IntValue.Where(e => e.Path == intvalue.Path.ToString());
                            foreach(var entity in entitys)
                            {
                                entity.Value = intvalue.Value;
                                context.IntValue.Update(entity);
                            }
                        }
                        context.SaveChanges();
                        context.Dispose();
                    }
                }
            }
        }
        private static void UpdateCrioPump()
        {
            lock(OPCObjects.OPCLocker)
            {
                lock(OPCObjects.SQLLocker)
                {
                    using (var context =new  MyDBContext())
                    {
                        var entitys = context.CrioPump.Where(e => e.Id == 1);
                        foreach(var entity in entitys)
                        {
                            entity.iAuto_mode = OPCObjects.CrioInput.Auto_mode;
                            entity.iCommand_manual = OPCObjects.CrioInput.Command_manual;
                            entity.sAuto_mode = OPCObjects.CrioStatus.Auto_mode;
                            entity.sBlocked = OPCObjects.CrioStatus.Blocked;
                            entity.sError = OPCObjects.CrioStatus.Error;
                            entity.sPower_On = OPCObjects.CrioStatus.Power_On;
                            entity.sTurn_On = OPCObjects.CrioStatus.Turn_On;
                            context.Update(entity);
                        }
                        context.SaveChanges();

                    }
                }
            }
        }
        private static void UpdateFVP()
        {
            lock(OPCObjects.OPCLocker)
            {
                lock(OPCObjects.SQLLocker)
                {
                    using(var context = new MyDBContext())
                    {
                        var entitys = context.FVP.Where(e => e.Id == 1);
                        foreach(var entity in entitys)
                        {
                            entity.Auto_mode = OPCObjects.FVPStatus.Auto_mode;
                            entity.Block = OPCObjects.FVPStatus.Block;
                            entity.Manual_start = OPCObjects.FVPStatus.Manual_start;
                            entity.Power_On = OPCObjects.FVPStatus.Power_On;
                            entity.Remote = OPCObjects.FVPStatus.Remote;
                            entity.Start = OPCObjects.FVPStatus.Start;
                            entity.Turn_On = OPCObjects.FVPStatus.Turn_On;
                            context.Update(entity);
                        }
                        context.SaveChanges();
                    }
                }
            }
        }
        private static void UpdateION()
        {
            lock(OPCObjects.OPCLocker)
            {
                lock(OPCObjects.SQLLocker)
                {
                    using(var context = new MyDBContext())
                    {
                        var entitys = context.Ion.Where(e => e.Id == 1);
                        foreach(var entity in entitys)
                        {
                            entity.Anod_I = OPCObjects.IonOutputFeedBack.Anod_I;
                            entity.Anod_I_SP = OPCObjects.IonInputSetPoint.Anod_I_SP;
                            entity.Anod_P = OPCObjects.IonOutputFeedBack.Anod_P;
                            entity.Anod_P_SP = OPCObjects.IonInputSetPoint.Anod_P_SP;
                            entity.Anod_U = OPCObjects.IonOutputFeedBack.Anod_U;
                            entity.Anod_U_SP = OPCObjects.IonInputSetPoint.Anod_U_SP;
                            entity.Heat_I = OPCObjects.IonOutputFeedBack.Heat_I;
                            entity.Heat_I_SP = OPCObjects.IonInputSetPoint.Heat_I_SP;
                            entity.Heat_P = OPCObjects.IonOutputFeedBack.Heat_P;
                            entity.Heat_P_SP = OPCObjects.IonInputSetPoint.Heat_P_SP;
                            entity.Heat_U = OPCObjects.IonOutputFeedBack.Heat_U;
                            entity.Heat_U_SP = OPCObjects.IonInputSetPoint.Heat_U_SP;
                            entity.icAuto_mod = OPCObjects.IonInputCommnd.Auto_mod;
                            entity.icManual_Start = OPCObjects.IonInputCommnd.Manual_Start;
                            entity.icManual_Stop = OPCObjects.IonInputCommnd.Manual_Stop;
                            entity.icReset_error = OPCObjects.IonInputCommnd.Reset_error;
                            entity.icStart = OPCObjects.IonInputCommnd.Start;
                            entity.icStop = OPCObjects.IonInputCommnd.Stop;
                            entity.sAuto_mode = OPCObjects.IonStatus.Auto_mode;
                            entity.sEmergancy_Stop = OPCObjects.IonStatus.Emergancy_Stop;
                            entity.sFailure = OPCObjects.IonStatus.Failure;
                            entity.sFilament_Failure = OPCObjects.IonStatus.Filament_Failure;
                            entity.sInterlock = OPCObjects.IonStatus.Interlock;
                            entity.sOther_Failure = OPCObjects.IonStatus.Other_Failure;
                            entity.sPower_Failure = OPCObjects.IonStatus.Power_Failure;
                            entity.sPower_on = OPCObjects.IonStatus.Power_on;
                            entity.sPower_Stop = OPCObjects.IonStatus.Power_Stop;
                            entity.sRepeat_Failure = OPCObjects.IonStatus.Repeat_Failure;
                            entity.sTemperature_Failure = OPCObjects.IonStatus.Temperature_Failure;
                            entity.sTemperature_Stop = OPCObjects.IonStatus.Temperature_Stop;
                            entity.sTurn_off = OPCObjects.IonStatus.Turn_off;
                            entity.sTurn_On = OPCObjects.IonStatus.Turn_On;
                            context.Update(entity);
                        }
                        context.SaveChanges();
                    }
                }
            }
        }
        private static void UpdateValves()
        {
            lock(OPCObjects.OPCLocker)
            {
                lock(OPCObjects.SQLLocker)
                {
                    using(var context = new MyDBContext())
                    {
                        foreach(var valve in OPCObjects.ValvesInput)
                        {
                            var entitys = context.Valve.Where(e => e.Id == valve.Key);
                            foreach(var entity in entitys)
                            {
                                entity.viAuto_mode = valve.Value.Auto_mode;
                                entity.viMan_command = valve.Value.Man_command;
                                entity.viService_mode = valve.Value.Service_mode;
                                entity.vsBlocked = OPCObjects.ValvesStatus[valve.Key].Blocked;
                                entity.vsClosed = OPCObjects.ValvesStatus[valve.Key].Closed;
                                entity.vsClosing = OPCObjects.ValvesStatus[valve.Key].Closing;
                                entity.vsOpened = OPCObjects.ValvesStatus[valve.Key].Opened;
                                entity.vsOpening = OPCObjects.ValvesStatus[valve.Key].Opening;
                                entity.vsServiced = OPCObjects.ValvesStatus[valve.Key].Serviced;
                                context.Update(entity);
                            }
                        }
                        context.SaveChanges();
                    }
                }
            }
        }


    }
}
