import {getCharacterByUserId} from "../../modules/CharacterManager.js"
import React from "react"
import { useState, useEffect } from "react"
import { CharacterCard } from "./CharacterCard.js"
import { Button } from "reactstrap"
import { useNavigate } from "react-router-dom"


export const CharacterList = ({getLoggedInUser}) =>{

    const [characters, updateCharacters] = useState([])
    const [user, setUser] = useState("")
    const navigate = useNavigate()
    
    useEffect(()=>{
        getLoggedInUser().then(res => setUser(res))
    },[])

    useEffect(()=>{
        getCharacterByUserId(user.firebaseId).then(res => {
            updateCharacters(res)
        })
    },[user])

    

    return(
        <>
        <section className="main-card-container row">
            {characters == null ? "You do not currently have any characters" : characters.map(res => <CharacterCard key={res.Id} character={res} updateCharacters={updateCharacters} user={user}/>)}
        </section>
        </>
    )
}