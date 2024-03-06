import { useEffect, useRef, useState } from "react"


export default function Input({ label, type = "text", ...props }) {

    const [show, setShow] = useState(false)
    const [inputtype, setInputtype] = useState(type)
    const inputref = useRef()

    useEffect(() => {

        if (show) {
            setInputtype("text")
            inputref.current.focus()

        }
        else if (type == "password") {
            setInputtype("password")
            inputref.current.focus()

        }



    }, [show])


    return (

        <label className="block relative flex bg-zinc-50 border rounded-sm focus-within:border-gray-500">
            <input ref={inputref} required={true} type={inputtype} className=" px-2  w-full h-[38px] text-xs outline-none  valid:pt-[10px] peer" {...props} />
            <small className="text-xs cursor-text pointer-events-none absolute top-1/2 left-2 text-gray-500 -translate-y-1/2 transition-all peer-valid:text-[10px] peer-valid:top-2.5">{label}</small>
            {type == "password" && props?.value && (
                <button onClick={() => setShow(!show)} type="button" className=" bg-white h-full flex items-center text-sm font-semibold pr-2.5">
                    {show ? "Gizle" : "Göster"}
                </button>

            )}
        </label>

    )

}