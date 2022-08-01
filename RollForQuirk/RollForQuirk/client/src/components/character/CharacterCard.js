import React, {useState, useEffect} from "react"
import { Card, CardBody, CardTitle, CardSubtitle, CardImg, CardImgOverlay } from "reactstrap"
import { CharacterDetails } from "./CharacterDetails"
import { editCharacter } from "../../modules/CharacterManager"
import { deleteCharacter } from "../../modules/CharacterManager"
import { getCharacterByUserId } from "../../modules/CharacterManager"

export const CharacterCard = ({character, updateCharacters, user}) =>{
    
    const [isOpen, updateIsOpen] = useState(false)
    const [edit, updateEdit] = useState(false)

    useEffect(()=>{
        getCharacterByUserId(user.firebaseId).then(res => {
            updateCharacters(res)
        })
    },[isOpen]) 

    const handleKeyPress = (event) =>{
        if(event.key === 'Escape' )
        {
            updateEdit(!edit)
        }else if(event.key === 'Enter')
        {
            editCharacter(character).then(updateEdit(!edit))

        }
    }


    const handleDelete = () =>{
        deleteCharacter(character)
            .then(updateIsOpen(!isOpen))
    }

    const imageSize = {
        maxHeight: 200,
        maxWidth: 300
    }

    return (
        <>
            
            <Card className="character-card-main container-sm col-md-4" onClick={()=> updateIsOpen(!isOpen)} style={{cursor: 'pointer', border: '1px solid black', boxShadow: '0px 0px 5px black'}}>
                <CardImg src={`/images/${character?.characterProfession?.characterProfession.toLowerCase()}-symbol.svg`} style={imageSize}/>
                <CardImgOverlay>
                <CardTitle className="bg-">{character?.characterName}</CardTitle>
                <CardBody>
                    <CardSubtitle>Race: {character?.characterRace?.characterRace}</CardSubtitle>
                    <CardSubtitle>Class: {character?.characterProfession?.characterProfession}</CardSubtitle>
                    <CardSubtitle>Alignment: {character?.characterAlignment?.characterAlignment} </CardSubtitle>
                </CardBody>
                </CardImgOverlay>
            </Card>
            <CharacterDetails character={character} isOpen={isOpen} updateEdit={updateEdit} edit={edit} handleDelete={handleDelete} handleKeyPress={handleKeyPress} updateIsOpen={updateIsOpen}/>
        </>

    )
}