import { FormGroup, Form, Button } from "reactstrap"
import { useParams } from "react-router-dom"
import { useEffect, useState } from "react"
import { getCharacterById } from "../../modules/CharacterManager"


export const EditCharacter = () =>{

    const [character, updateCharacter] = useState()
    const charId = useParams().id

    useEffect(()=>{
        getCharacterById(charId).then(res => updateCharacter(res))
        console.log(character)
        
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
            <input type="text" id="characterProfession" value={character?.profession?.characterProfession}/>

            </FormGroup>
            <FormGroup>
            <label htmlFor="race-select">Character an alignment: </label>
            <input type="text" id="characterAlignment" value={character?.alignment?.characterAlignment}/>

            </FormGroup>
            <FormGroup>
                {character?.traits.map(t => <p>{t.characterTrait}</p>)}
            </FormGroup>
            <FormGroup>
                {/* {traits === null ? <><Button onClick={generate}>Generate Traits</Button></> : <><Button onClick={""}>Generate Traits</Button><Button onClick={""}>Save</Button></>} */}
            </FormGroup>
        </fieldset>
    </Form>
    )
}