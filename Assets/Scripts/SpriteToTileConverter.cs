using UnityEngine;
using UnityEditor;
using UnityEngine.Tilemaps;

public class SpriteToTileConverter : MonoBehaviour
{
    public Texture2D spriteSheet; // 스프라이트 시트
    public Tile tilePrefab; // 타일 프리팹
    public Tilemap tilemap; // 타일맵

    [ContextMenu("Convert Sprites to Tiles")]
    public void ConvertSpritesToTiles()
    {
        if (spriteSheet == null || tilePrefab == null || tilemap == null)
        {
            Debug.LogError("Please assign the sprite sheet, tile prefab, and tilemap.");
            return;
        }

        // 각 타일의 크기 (예: 32x32)
        int tileWidth = 32; // 수정할 수 있음
        int tileHeight = 32; // 수정할 수 있음

        // 스프라이트 시트에서 타일 생성
        for (int y = 0; y < spriteSheet.height; y += tileHeight)
        {
            for (int x = 0; x < spriteSheet.width; x += tileWidth)
            {
                // 스프라이트 생성
                var sprite = Sprite.Create(spriteSheet, new Rect(x, y, tileWidth, tileHeight), new Vector2(0.5f, 0.5f));

                // 타일 생성
                Tile newTile = Instantiate(tilePrefab);
                newTile.sprite = sprite;

                // 타일을 타일맵에 추가
                tilemap.SetTile(tilemap.WorldToCell(new Vector3(x / (float)tileWidth, y / (float)tileHeight, 0)), newTile);
            }
        }

        Debug.Log("Tiles converted successfully!");
    }
}

