import React, {useState} from "react"
import { useNavigate } from "react-router-dom"
import { Card, CardBody, CardText, CardTitle, CardSubtitle, Button } from "reactstrap"
import { CharacterDetails } from "./CharacterDetails"
import { editCharacter } from "../../modules/CharacterManager"

export const CharacterCard = ({character}) =>{
    
    const [isOpen, updateIsOpen] = useState(false)
    const [edit, updateEdit] = useState(false)

    const handleKeyPress = (event) =>{
        if(event.key === 'Escape' )
        {
            updateEdit(!edit)
        }else if(event.key === 'Enter')
        {
            editCharacter(character).then(updateEdit(!edit))

        }
    }

    return (
        <>
            
            <Card className="container-sm col-md-4" onClick={()=> updateIsOpen(!isOpen)} style={{cursor: 'pointer'}}>
                <CardTitle>{character?.characterName}</CardTitle>
                <CardBody>
                    <CardSubtitle>Race: {character?.characterRace?.characterRace}</CardSubtitle>
                    <CardSubtitle>Class: {character?.characterProfession?.characterProfession}</CardSubtitle>
                    <CardSubtitle>Alignment: {character?.characterAlignment?.characterAlignment} </CardSubtitle>
                    {/* <CardSubtitle>Traits: {character?.traits?.map(res => <CardText>{res.characterTrait}</CardText>)}</CardSubtitle> */}
                </CardBody>
            </Card>
            <CharacterDetails character={character} isOpen={isOpen} updateEdit={updateEdit} edit={edit} handleKeyPress={handleKeyPress} updateIsOpen={updateIsOpen}/>
        </>

    )
}