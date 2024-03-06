
import { useEffect, useRef, useState} from "react";
import Input from "./input.js";
import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

function App() {
    const ref = useRef()
    const [UserName, setUserName] = useState('');
    const [Password, setPassword] = useState("")
    
    const navigate = useNavigate();

    const enable = UserName && Password

    useEffect(() => {
        localStorage.clear();

    }, [ref]) 
    
    const handleSubmit = async (e) => {
        e.preventDefault();

      try {
            const response = await axios.post('auth/login', {
                UserName,
                Password
            });
            console.log(response.data);
            localStorage.setItem('accessToken', response.data.success);
            localStorage.setItem('UserId', response.data.intMessage);
            console.log('Kullanıcı girişi başarılı. Token:', localStorage.getItem('accessToken'));
            
            navigate('/fetch-data');
           window.location.reload();

        } catch (error) {
            console.error('Kullanıcı girişi başarısız. Hata:', error.response.data);
            toast.error("Kullanıcı Adı veya Şifre yanlış!")
            setPassword('');
            
        } 
    };








    return(
        <div className="h-full w-full flex flex-wrap overflow-auto items-center gap-x-8 justify-center content-center self-auto pt-12">

            <div className="w-[350px] grid gap-y-3 pt-2 self-start">
                <div className="bg-white border  px-[40px] pt-8 pb-6">
                <a href="#" className="flex justify-center mb-8">
          <img className="h-[200px]" src="https://upload.wikimedia.org/wikipedia/commons/9/99/Sample_User_Icon.png" alt="user" />
        </a> 
                    <form className="grid gap-y-1.5" onSubmit={handleSubmit}>
                        <Input type="text" value={UserName} onChange={(e) => setUserName(e.target.value)} label="Kullanıcı Adı" />
                        <Input type="password" value={Password} onChange={(e) => setPassword(e.target.value)} label="Şifre" />
                        <button type="sumbit" disabled={!enable} className=" h-[35px] mt-1 bg-brand text-white text-sm rounded-xl font-semibold disabled:opacity-50">Giriş</button>
                        <ToastContainer />



                    </form>
                </div>



            </div>


      </div>
    );
  }

export default App;