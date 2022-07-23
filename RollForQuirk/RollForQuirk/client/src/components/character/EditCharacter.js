import { useLocation } from "react-router-dom"
import { FormGroup, Form, Button } from "reactstrap"
import { useParams } from "react-router-dom"
import { useEffect, useState } from "react"
import { getCharacterById } from "../../modules/CharacterManager"
import { GetProfessionById } from "../../modules/ProfessionManager"
import { getAlignmentById } from "../../modules/AlignmentManager"
import { getRaceById } from "../../modules/RaceManager"


export const EditCharacter = () =>{

    const [character, updateCharacter] = useState()
    const [alignment, updateAlignment] = useState()
    const [profession, updateProfession] = useState()
    const [race, updateRace] = useState()
    const charId = useParams()

    useEffect(()=>{
        getCharacterById(charId.id).then(res => updateCharacter(res))
    },[])

    useEffect(()=>{
        getAlignmentById(charId.id).then(res => updateAlignment(res))
    },[])

    useEffect(()=>{
        getRaceById(charId.id).then(res => updateRace(res))
    },[])

    useEffect(()=>{
        GetProfessionById(charId.id).then(res => updateProfession(res))
    },[])




    return(
        <Form>
        <fieldset>
            <FormGroup>
                <label htmlFor="name">Character Name: </label>
                <input type="text" placeholder="character name" id="characterName" onChange={(e) => character.characterName = e.target.value}></input>
            </FormGroup>
            <FormGroup>
            <label htmlFor="race-select">Character Race: </label>
            <input type="text" id="characterRace" value={character?.characterRace?.characterRace}/>
            </FormGroup>
            <FormGroup>
            <label htmlFor="class-select">Character a class: </label>
            <input type="text" id="characterProfession" value={profession?.characterProfession}/>

            </FormGroup>
            <FormGroup>
            <label htmlFor="race-select">Character an alignment: </label>
            <input type="text"/>

            </FormGroup>
            <FormGroup>
                {/* {traits === null ? "" : traits.map(t => <p>{t.characterTrait}</p>)} */}
            </FormGroup>
            <FormGroup>
                {/* {traits === null ? <><Button onClick={generate}>Generate Traits</Button></> : <><Button onClick={""}>Generate Traits</Button><Button onClick={""}>Save</Button></>} */}
            </FormGroup>
        </fieldset>
    </Form>
    )
}