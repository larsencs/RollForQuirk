import {getCharacterByUserId} from "../../modules/CharacterManager.js"
import React from "react"
import { useState, useEffect } from "react"
import { CharacterCard } from "./CharacterCard.js"


export const CharacterList = ({getLoggedInUser}) =>{

    const [characters, updateCharacters] = useState([])
    const [user, setUser] = useState("")
    
    useEffect(()=>{
        getLoggedInUser().then(res => setUser(res))
    },[])

    useEffect(()=>{
        getCharacterByUserId(user.firebaseId).then(res => {
            console.log("response", res)
            updateCharacters(res)
        })
    },[user])

    return(

    <section>
        {characters == null ? "You do not currently have any characters" : characters.map(res => <CharacterCard key={res.Id} character={res}/>)}
    </section>
    )
}