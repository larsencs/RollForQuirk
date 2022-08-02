import React, {useState, useEffect} from "react"
import { Card, CardBody, CardTitle, CardSubtitle, CardImg, CardImgOverlay, CardText } from "reactstrap"
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
            
            <Card className="character-card-main container-sm col-md-3 m-1" onClick={()=> updateIsOpen(!isOpen)}>

                
                <CardTitle className="bg-"><h3>{character?.characterName}</h3></CardTitle>
                <div>
                <CardImg src={`/images/${character?.characterProfession?.characterProfession.toLowerCase()}-symbol.svg`} style={imageSize}/>
                </div>
                <CardBody>
                    <CardText>Race: {character?.characterRace?.characterRace}</CardText>
                    <CardText>Class: {character?.characterProfession?.characterProfession}</CardText>
                    <CardText>Alignment: {character?.characterAlignment?.characterAlignment} </CardText>
                </CardBody>
                
            </Card>
            <CharacterDetails character={character} isOpen={isOpen} updateEdit={updateEdit} edit={edit} handleDelete={handleDelete} handleKeyPress={handleKeyPress} updateIsOpen={updateIsOpen}/>
        </>

    )
}